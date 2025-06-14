﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.IO.Pipes;

// ------------- TODO
// - delete a label
// - manage 'date' in advanced search
// - add KIND folder?
// ------------------------

namespace Calder1
{
	public partial class MainForm : Form
	{
		#region const
		private const string APP_NAME = "Calder1";
        private const string APP_VERSION = "(v0.60)";
		public const string PIPE_NAME = "Calder1Pipe";

		//--- output table constant
		private const string TAB_HEADER_TITLE = "Title";
		private const string TAB_HEADER_DATE = "Date";
		private const string TAB_HEADER_LABELS = "Labels";
		private const string TAB_HEADER_FAVORITE = "Fav";
		private const string TAB_HEADER_LANGUAGE = "Lang";
        private const string TAB_HEADER_KIND = "Kind";
        private const string TAB_HEADER_INDEX = "Index";

		//--- menu
		private const string MENU_EDIT_RECORD = "Edit record";
		private const string MENU_DELETE_RECORD = "Delete record";
		private const string MENU_COPY_TITLE = "Copy title";
		private const string MENU_COPY_LABELS = "Copy labels";
        private const string MENU_TOGGLE_FAV = "Toggle Favorite";
		private const string MENU_RENAME_FILE = "Rename file";
		private const string MENU_EXPORT_FILE = "Export file";
		private const string MENU_COPY_FILE_PATH = "Copy file path";
		private const string MENU_COPY_FILE_NAME = "Copy file name";
        private const string MENU_COPY_FILE_NAME_NOEXT = "Copy file name (no ext)";
        #endregion

        #region field
        private Calder1Repository _repo = null;
		private RecordForm _recForm = new RecordForm();
        private SearchForm _searchForm = new SearchForm();
        private bool _openingRepo;
		private object _state = new object();
		private NamedPipeServerStream _pipeServer;
        private bool _firstShow;
        #endregion

        #region form
        public MainForm()
		{
			InitializeComponent();
            Text = APP_NAME + " " + APP_VERSION;

			ssInfoRecord.Text = "";
			ssInfoSelected.Text = "";
            _firstShow = true;

            if (Calder1.Properties.Settings.Default.Repositories != null)
			{
				foreach (var item in Calder1.Properties.Settings.Default.Repositories)
				{
					tscRepo.Items.Add(item.ToString());
				}
			}

			string[] args = Environment.GetCommandLineArgs();
			if (args.Length == 2)
			{
				OpenRepo(args[1]);
			}
			else
			{
				//should it open the last one?
                if (Calder1.Properties.Settings.Default.Repositories != null && Calder1.Properties.Settings.Default.Repositories.Count > 0)
                {
                    OpenRepo(Calder1.Properties.Settings.Default.Repositories[0]);
                }
			}

			//Open pipe connection (see Program.cs)
			_pipeServer = new NamedPipeServerStream(MainForm.PIPE_NAME, PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
			_pipeServer.BeginWaitForConnection(PipeAsyncCallback, _state);

            this.MouseWheel += MainForm_MouseWheel;
            gridView.MouseWheel += MainForm_MouseWheel;
        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            // zoom
            if (Control.ModifierKeys == Keys.Control)
            {
                this.Font = new Font(this.Font.FontFamily, this.Font.Size + (e.Delta > 0 ? 1 : -1));
                gridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                toolStrip1.Font = this.Font;
                foreach (ToolStripItem item in toolStrip1.Items)
                {
                    item.Font = this.Font;
                }
                _searchForm.Font = this.Font;
                _recForm.Font = this.Font;
            }
        }

        /// <summary>
        /// Pipe connection handler
        /// </summary>
        /// <param name="ar"></param>
        public void PipeAsyncCallback(IAsyncResult ar)
		{
			//restore from notification area with pipe communication
			string s = "1,"; //pro-debug
			try
			{
				s += "2,";
				if (this.InvokeRequired)
				{
					s += "5,";
					this.Invoke((MethodInvoker)delegate
					{
						notifyIcon1_DoubleClick(null, null);
					});
				}
				else
				{
					s += "6,";
					notifyIcon1_DoubleClick(null, null);
				}

				s += "7,";
				_pipeServer.EndWaitForConnection(ar);

				s += "8,";
				_pipeServer = new NamedPipeServerStream(MainForm.PIPE_NAME, PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
				_pipeServer.BeginWaitForConnection(PipeAsyncCallback, _state);
			}
			catch(Exception ex)
			{
				s += ex.ToString();
			}
			//MessageBox.Show(s); //pro-debug
		}

		private void notifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			//restore from notification area
            if (this.Visible)
                this.Hide();
            this.Show();
			this.WindowState = FormWindowState.Normal;
			this.BringToFront();
            this.TopMost = true;
            Application.DoEvents();
            this.TopMost = false;
        }

		private void MainForm_Resize(object sender, EventArgs e)
		{
			//minimize to notification area
			if (WindowState == FormWindowState.Minimized)
			{
				this.Hide();
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
            SaveRepo();

			//--- save repositories...
			Calder1.Properties.Settings.Default.Repositories = new System.Collections.Specialized.StringCollection();
            if (tscRepo.Text != "")
                Calder1.Properties.Settings.Default.Repositories.Add(tscRepo.Text);

			for (int i = 0; i < tscRepo.Items.Count; i++)
			{
                if (!Calder1.Properties.Settings.Default.Repositories.Contains(tscRepo.Items[i].ToString()))
				    Calder1.Properties.Settings.Default.Repositories.Add(tscRepo.Items[i].ToString());	
			}
			Calder1.Properties.Settings.Default.Save();

			//--- save searched keywords?!?!?!
			//...mah...
		}

		private void gridView_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		}

		private void gridView_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length != 1)
			{
				MessageBox.Show("One file at the time!", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			AddRecord(files[0], true);
		}

        private void tstSearch_TextChanged(object sender, EventArgs e)
        {
            if (_repo == null) return;
            UpdateUI();
        }

        private void tstSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_repo == null) return;
            
            if (e.KeyChar == 13 && Control.ModifierKeys == Keys.Shift)
                gridView.Focus();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (_repo == null) return;
			if (e.Shift || e.Alt) return;

			if (e.Control && e.KeyCode == Keys.S)
				tstSearch.Focus();

			if (e.Control && e.KeyCode == Keys.G)
				gridView.Focus();

			if (e.Control && e.KeyCode == Keys.F)
			{
				tsbFavorite.Checked = !tsbFavorite.Checked;
				UpdateUI();
            }

			if (!e.Control && e.KeyCode == Keys.F4)
			{
				tscRepo.Focus();
				tscRepo.DroppedDown = true;
			}
		}

		private void tsbOpenRepository_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Repository file";
			if (_repo != null)
				ofd.InitialDirectory = Path.GetDirectoryName(_repo.CSVFilePath);
			ofd.Filter = "(repo)|*.repo";

			if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				return;

			OpenRepo(ofd.FileName);
		}

        private void tscRepo_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (_openingRepo)
				return;

            OpenRepo(tscRepo.Text);
        }

		private void tsbAdd_Click(object sender, EventArgs e)
		{
			string text = Clipboard.GetText();
			if (text == null || text.Split('\n').Length > 1)
			{
				AddRecord(null, false);
				return;
			}

			if (text.StartsWith("\"") && text.EndsWith("\"")) //Copy file path (shift+right click) adds extra quotes
				text = text.Substring(1, text.Length - 2);

			if (!IsValidURL(text) && !IsValidFilePath(text))
				AddRecord(null, false);
			else
				AddRecord(text, false);
		}

		private void tsbFavorite_Click(object sender, EventArgs e)
		{
			if (_repo == null) return;
			UpdateUI();
        }

        private void tsbShow10_Click(object sender, EventArgs e)
        {
            if (_repo == null) return;
            UpdateUI();
        }

        private void gridView_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
            if (_repo == null) return;
            int contentIndex = int.Parse(gridView.Rows[e.RowIndex].Cells[TAB_HEADER_INDEX].Value.ToString());

			Calder1Record r = _repo.Content[contentIndex];
            if (r.Kind == Calder1Repository.KIND_DOC)
            {
                ssInfoRecord.Text = Path.GetFileName(_repo.Content[contentIndex].URL);
                try
                {
                    string filePath = _repo.GetRecordPath(r);

                    string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                    double len = new FileInfo(filePath).Length;
                    int order = 0;
                    while (len >= 1024 && order < sizes.Length - 1)
                    {
                        order++;
                        len = len / 1024;
                    }

                    ssInfoRecord.Text += " (" + String.Format("{0:0.##} {1}", len, sizes[order]) + ")";
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            else
            {
                ssInfoRecord.Text = r.URL;
            }
		}

        private void gridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_repo == null || e.RowIndex < 0) return;
            int contentIndex = int.Parse(gridView.Rows[e.RowIndex].Cells[TAB_HEADER_INDEX].Value.ToString());
            Calder1Record r = _repo.Content[contentIndex];
			OpenURLFile(r);
        }


		private void gridView_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (_repo == null) return;

            if (Control.ModifierKeys == Keys.Control && e.KeyChar == 10) // CTRL+Return to open document
			{
				int contentIndex = int.Parse(gridView.Rows[gridView.CurrentCell.RowIndex].Cells[TAB_HEADER_INDEX].Value.ToString());
				Calder1Record r = _repo.Content[contentIndex];
				OpenURLFile(r);
				return;
			}
		}

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (_repo == null) return;

            if (e.KeyCode == Keys.Oemplus && e.Control) // CTRL+
            {
                gridView.Font = new Font(gridView.Font.Name, gridView.Font.Size + 1); //%%% chiamare stessa funzione di zoom
            }
            if (e.KeyCode == Keys.OemMinus && e.Control) // CTRL-
            {
                gridView.Font = new Font(gridView.Font.Name, gridView.Font.Size - 1); //%%% chiamare stessa funzione di zoom
            }

            if (e.KeyCode == Keys.F2) // F2 to edit (check also SHIFT+Return)
            {
                int rowIndex = gridView.CurrentCell.RowIndex;
                int contentIndex = int.Parse(gridView.Rows[rowIndex].Cells[TAB_HEADER_INDEX].Value.ToString());
                Calder1Record r = _repo.Content[contentIndex];
                EditRecord(r, rowIndex, true);
                return;
            }

            if (e.KeyCode == Keys.Enter && e.Shift) // SHIFT+Return to edit record
            {
                int rowIndex = gridView.CurrentCell.RowIndex;
                int contentIndex = int.Parse(gridView.Rows[gridView.CurrentCell.RowIndex].Cells[TAB_HEADER_INDEX].Value.ToString());
                Calder1Record r = _repo.Content[contentIndex];
                EditRecord(r, rowIndex, false);
                e.SuppressKeyPress = true;
                return;
            }
        }

        private void gridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (_repo == null) return;

            int row = gridView.HitTest(e.X, e.Y).RowIndex;
            if (row < 0)
                return;

            if (gridView.SelectedRows.Count < 1)
                return;

            if (e.Button == MouseButtons.Left)
            {
                int contentIndex = int.Parse(gridView.Rows[row].Cells[TAB_HEADER_INDEX].Value.ToString());
                ssInfoRecord.Text = _repo.Content[contentIndex].URL;
                return;
            }

            if (e.Button != MouseButtons.Right) return;

            ContextMenu m = new ContextMenu();
            if (gridView.SelectedRows.Count == 1)
            {
                int contentIndex = int.Parse(gridView.Rows[row].Cells[TAB_HEADER_INDEX].Value.ToString());
                m.MenuItems.Add(MENU_EDIT_RECORD, RightClickMenu);
                m.MenuItems.Add(MENU_DELETE_RECORD, RightClickMenu);
                m.MenuItems.Add(MENU_COPY_TITLE, RightClickMenu);
                m.MenuItems.Add(MENU_COPY_LABELS, RightClickMenu);
                m.MenuItems.Add(MENU_TOGGLE_FAV, RightClickMenu);
                if (_repo.Content[contentIndex].Kind == Calder1Repository.KIND_DOC)
                {
                    m.MenuItems.Add("-");
                    m.MenuItems.Add(MENU_RENAME_FILE, RightClickMenu);
                    m.MenuItems.Add(MENU_EXPORT_FILE, RightClickMenu);
                    m.MenuItems.Add(MENU_COPY_FILE_PATH, RightClickMenu);
                    m.MenuItems.Add(MENU_COPY_FILE_NAME, RightClickMenu);
                    m.MenuItems.Add(MENU_COPY_FILE_NAME_NOEXT, RightClickMenu);
                }
            }
            else
            {
                m.MenuItems.Add(MENU_COPY_TITLE, RightClickMenu);
                m.MenuItems.Add(MENU_TOGGLE_FAV, RightClickMenu);
                m.MenuItems.Add(MENU_EXPORT_FILE, RightClickMenu);
                m.MenuItems.Add(MENU_COPY_FILE_PATH, RightClickMenu);
                m.MenuItems.Add(MENU_COPY_FILE_NAME, RightClickMenu);
                m.MenuItems.Add(MENU_COPY_FILE_NAME_NOEXT, RightClickMenu);
            }
            
            m.Show(gridView, new Point(e.X, e.Y));
        }

		/// <summary>
		/// gridView ContextMenu event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void RightClickMenu(object sender, EventArgs e)
        {
            // list of all selected rows
            List<Calder1Record> records = new List<Calder1Record>();
            for (int i = gridView.SelectedRows.Count - 1; i >= 0; i--)
            {
                int row = gridView.SelectedRows[i].Index;
                int contentIndex = int.Parse(gridView.Rows[row].Cells[TAB_HEADER_INDEX].Value.ToString());
                Calder1Record recordRC = _repo.Content[contentIndex];
                records.Add(recordRC);
            }
            Calder1Record record1RightClick = records[0];
            int record1RowIndex = gridView.SelectedRows[0].Index;

            // actions
            string menu = ((MenuItem)sender).Text;
			if (menu == MENU_EDIT_RECORD)
            {
                EditRecord(record1RightClick, record1RowIndex, false);
                return;
            }

			if (menu == MENU_DELETE_RECORD)
			{
				if (MessageBox.Show("Delete " + Path.GetFileName(record1RightClick.URL) + "?", APP_NAME, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
				_repo.Content.Remove(record1RightClick);
				if (record1RightClick.Kind == Calder1Repository.KIND_DOC)
				{
					try
					{
						File.Delete(_repo.GetRecordPath(record1RightClick));
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error deleting " + _repo.GetRecordPath(record1RightClick), APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
						ex.ToString();
					}
				}
				UpdateUI();
                SelectRecordUI(record1RowIndex - 1);
                return;
			}

			if (menu == MENU_COPY_TITLE)
			{
                string clip = "";
                for (int i = 0; i < records.Count; i++)
                {
                    clip += records[i].Title;
                    if (i != records.Count - 1) clip += "\n";
                }
                Clipboard.SetText(clip);
                return;
			}

			if (menu == MENU_COPY_LABELS)
			{
                string clip = "";
                for (int i = 0; i < records.Count; i++)
                {
                    clip += records[i].Labels;
                    if (i != records.Count - 1) clip += "\n";
                }
                Clipboard.SetText(clip);
				return;
			}

            if (menu == MENU_TOGGLE_FAV)
            {
                for (int i = 0; i < records.Count; i++)
                {
                    records[i].InvertFavorite();
                }
                UpdateUI();
                SelectRecordUI(record1RowIndex);
                return;
            }

			if (menu == MENU_RENAME_FILE)
			{
				InputForm rf = new InputForm();
				string fileNameOld = Path.GetFileName(record1RightClick.URL);
				rf.SetInput("Rename: ", fileNameOld);
				if (rf.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
				string fileNameNew = rf.GetInputText();
				try
				{
					File.Move(Path.Combine(_repo.DirPath, fileNameOld), Path.Combine(_repo.DirPath, fileNameNew));
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error on rename: " + fileNameNew, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
					ex.ToString();
				}
				record1RightClick.URL = fileNameNew;
				return;
			}

			if (menu == MENU_EXPORT_FILE)
			{
                FolderBrowserDialog sfd = new FolderBrowserDialog();
				sfd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
					return;

                string filePathNew = "";
                try
				{
                    for (int i = 0; i < records.Count; i++)
                    {
                        if (records[i].Kind != Calder1Repository.KIND_DOC)
                            continue;

                        filePathNew = Path.Combine(sfd.SelectedPath, Path.GetFileName(records[i].URL));
                        File.Copy(_repo.GetRecordPath(records[i]), filePathNew);
                    }
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error on copy: " + filePathNew, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
					ex.ToString();
				}
				return;
			}

			if (menu == MENU_COPY_FILE_PATH || menu == MENU_COPY_FILE_NAME || menu == MENU_COPY_FILE_NAME_NOEXT)
            {
                string cpData = "";
                try
                {
                    for (int i = 0; i < records.Count; i++)
                    {
                        if (records[i].Kind != Calder1Repository.KIND_DOC)
                            continue;

                        if (menu == MENU_COPY_FILE_PATH)
                        {
                            cpData += _repo.GetRecordPath(records[i]);
                        }
                        else if (menu == MENU_COPY_FILE_NAME)
                        {
                            cpData += Path.GetFileName(records[i].URL);
                        }
                        else if (menu == MENU_COPY_FILE_NAME_NOEXT)
                        {
                            cpData += Path.GetFileNameWithoutExtension(records[i].URL);
                        }

                        if (records.Count > 1)
                        {
                            cpData += "\n";
                        }
                    }
                    Clipboard.SetText(cpData.TrimEnd('\r', '\n'));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error ", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ex.ToString();
                }
                return;
			}
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            DialogResult dr = _searchForm.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.OK)
            {
                tsbSearch.Checked = false;
                tstSearch.Enabled = true;
                tsbFavorite.Enabled = true;
                tsbAdd.Enabled = true;
                tscRepo.Enabled = true; 
                return;
            }
            tstSearch.Text = "";
            tsbSearch.Checked = true;
            tstSearch.Enabled = false;
            tsbFavorite.Enabled = false;
            tsbAdd.Enabled = false;
            tscRepo.Enabled = false;

            UpdateUI(_searchForm.GetSearchText(), -1, _searchForm.HasFavorite(), _searchForm.HasMatchCase(), _searchForm.HasURL(), _searchForm.HasTitle(), _searchForm.HasLabels(), _searchForm.HasKeywords());
        }

        private void gridView_VisibleChanged(object sender, EventArgs e)
        {
            // remove auto size column
            //gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // %colresize%
        }

        #endregion

        #region func

        /// <summary>
        /// Opens URL or file
        /// </summary>
        /// <param name="r"></param>
        private void OpenURLFile(Calder1Record r)
		{
			try
			{
				if (r.Kind == Calder1Repository.KIND_DOC) Process.Start(_repo.GetRecordPath(r));
				else Process.Start(r.URL);

			}
			catch (Exception ex)
			{
				ex.ToString();
				MessageBox.Show("Error opening record", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Select the record in the UI
		/// </summary>
		/// <param name="r"></param>
		private void SelectRecordUI(int row)
		{
            if (row < 0 || row >= gridView.Rows.Count)
                return;
			gridView.Rows[row].Selected = true;
			gridView.CurrentCell = gridView.Rows[row].Cells[0];
			gridView.FirstDisplayedScrollingRowIndex = gridView.SelectedRows[0].Index;
		}
                
		/// <summary>
		/// Adds a record in the repository
		/// </summary>
		/// <param name="filePathOrURL"></param>
		private void AddRecord(string filePathOrURL, bool acceptUpdate)
		{
			if (_repo == null) return;

			if (acceptUpdate && IsValidFilePath(filePathOrURL) && (_repo.HasFile(Path.GetFileName(filePathOrURL))))
			{
				if (MessageBox.Show("File already present, do you want to update the file?", APP_NAME, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					ManageFileCopyMove(filePathOrURL);
				}
				return;
			}

            Calder1Record lastSelectedRecord = null;
            if (gridView.CurrentCell != null && gridView.CurrentCell.RowIndex >= 0)
            {
                int contentIndex = int.Parse(gridView.Rows[gridView.CurrentCell.RowIndex].Cells[TAB_HEADER_INDEX].Value.ToString());
                lastSelectedRecord = _repo.Content[contentIndex];
            }

            _recForm.SetRepository(_repo, null, lastSelectedRecord, false);
            if (filePathOrURL != null && IsValidURL(filePathOrURL))
            {
                _recForm.SetURL(filePathOrURL);
            }
            else
            {
                _recForm.SetFilePath(filePathOrURL);
            }
            DialogResult dr = _recForm.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.OK) return;

            Calder1Record r = _recForm.GetRecord();

			//checks if it's valid
			if (string.IsNullOrEmpty(r.Title) || string.IsNullOrWhiteSpace(r.Title) || string.IsNullOrEmpty(r.URL) || string.IsNullOrWhiteSpace(r.URL))
			{
				MessageBox.Show("Wrong URL/Title", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//checks if already present
			if (_repo.Content.FindIndex(x => x.URL == r.URL) >= 0)
			{
				MessageBox.Show("File/URL already present", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

            if (r.Kind == Calder1Repository.KIND_DOC)
			{
				if (!ManageFileCopyMove(_recForm.GetFilePath()))
					return;
			}

			_repo.Content.Add(r);

            string prevSearch = tstSearch.Text;
            bool prevFavorite = tsbFavorite.Checked;

            // reset search & favorite
            tstSearch.Text = "";
			tsbFavorite.Checked = false;
            
            // restore search & favorite
            if (prevFavorite)
                tsbFavorite.Checked = true;
            tstSearch.Text = prevSearch; // restore previous search
            UpdateUI();
            SelectRecordUI(gridView.Rows.Count - 1);
        }

		/// <summary>
		/// Edit a record with the UI
		/// </summary>
		/// <param name="r"></param>
		private void EditRecord(Calder1Record r, int rowIndex, bool selectText)
		{
            _recForm.SetRepository(_repo, r, null, selectText);
			if (_recForm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
			r.CopyData(_recForm.GetRecord());
			UpdateUI();
            SelectRecordUI(rowIndex);
		}

		/// <summary>
		/// Manages question for copy/move file into the repository
		/// </summary>
		/// <param name="filePathOrURL"></param>
		/// <returns></returns>
		private bool ManageFileCopyMove(string filePathOrURL)
		{
			try
			{
                string filePathDest = Path.Combine(_repo.DirPath, Path.GetFileName(filePathOrURL));
                if (MessageBox.Show("Press yes to move the file or no to copy it", APP_NAME, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (File.Exists(filePathDest))
                        File.Delete(filePathDest);
                    File.Move(filePathOrURL, filePathDest);
                }
                else
                {
                    File.Copy(filePathOrURL, filePathDest);
                }

				return true;
			}
			catch (Exception ex)
			{
				ex.ToString();
				MessageBox.Show("Error on copying/moving file", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		/// <summary>
		/// Opens a repository
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="dirPath"></param>
		private void OpenRepo(string repoFilePath)
		{
            if (_openingRepo)
                return;

			if (string.IsNullOrEmpty(repoFilePath))
				return;

            _openingRepo = true;

            //save previous repo if necessary
            SaveRepo();

			_repo = new Calder1Repository(repoFilePath);
			if (!_repo.Open())
			{
				MessageBox.Show("Error opening repository", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _openingRepo = false;
				return;
			}

			if (!tscRepo.Items.Contains(repoFilePath))
				tscRepo.Items.Add(repoFilePath);
			tscRepo.Text = repoFilePath;
			Text = APP_NAME + " " + APP_VERSION + " - " + _repo.CSVFilePath;

            //MTB [26/12/2019]:
            //UpdateUI(null, tsbFavorite.Checked, false);
            tstSearch.Text = "";
            UpdateUI();
            
            _openingRepo = false;
		}

		private bool UpdateUI()
		{
            int maxShow = -1;
            if (tsbShow10.Checked) maxShow = 10;

            return UpdateUI(tstSearch.Text, maxShow, tsbFavorite.Checked, false, true, true, true, true);
		}

		/// <summary>
		/// Load repo in UI accordling with searching parameter
		/// </summary>
		/// <param name="searchText"></param>
		/// <returns></returns>
        private bool UpdateUI(string searchText, int maxShow, bool favorite, bool matchCase, bool alsoURL, bool alsoTitle, bool alsoLabels, bool alsoKeywords)
		{
			if (_repo == null) return false;

			string[] fields = null;
			if (!string.IsNullOrEmpty(searchText) && !string.IsNullOrWhiteSpace(searchText))
			{
                searchText = searchText.Trim();
                if (!matchCase)
                    searchText = searchText.ToLower();
                fields = searchText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			}

			DataTable table = new DataTable();
			table.Columns.Add(TAB_HEADER_TITLE);
			table.Columns.Add(TAB_HEADER_DATE, typeof(DateTime));
			table.Columns.Add(TAB_HEADER_LABELS);
			table.Columns.Add(TAB_HEADER_FAVORITE);
			table.Columns.Add(TAB_HEADER_LANGUAGE);
            table.Columns.Add(TAB_HEADER_KIND);
            table.Columns.Add(TAB_HEADER_INDEX);

			bool res = false;

            //if (maxShow <= 0 || string.IsNullOrEmpty(searchText))
            if (maxShow <= 0)
            { 
                for (int i = 0; i < _repo.Content.Count; i++)
                {
                    Calder1Record item = _repo.Content[i];
                    if (item.Contains(fields, true, true, matchCase, alsoURL, alsoTitle, alsoLabels, alsoKeywords) && (!favorite || item.IsFavorite()))
				    {
					    res = true;
					    table.Rows.Add(new object[] { item.Title, item.Date, item.Labels, item.Favorite, item.Language, item.Kind, i });
				    }
			    }
            }
            else
            {
                List<object[]> items = new List<object[]>();
                for (int i = _repo.Content.Count - 1; i >= 0; i--)
                {
                    Calder1Record item = _repo.Content[i];
                    if (item.Contains(fields, true, true, matchCase, alsoURL, alsoTitle, alsoLabels, alsoKeywords) && (!favorite || item.IsFavorite()))
                    {
                        res = true;
                        items.Add(new object[] { item.Title, item.Date, item.Labels, item.Favorite, item.Language, item.Kind, i });
                        if (maxShow <= items.Count)
                            break;
                    }
                }

                // reverting the order
                for (int i = items.Count - 1; i >= 0; i--)
                {
                    table.Rows.Add(items[i]);
                }
            }

            //gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; // %colresize%
            gridView.DataSource = table;

            if (_firstShow)
            {
                _firstShow = false;
                gridView.Columns[0].Width = 680;
                gridView.Columns[1].Width = 80;
                gridView.Columns[2].Width = 230;
                gridView.Columns[3].Width = 40;
                gridView.Columns[4].Width = 40;
                gridView.Columns[5].Width = 40;
                gridView.Columns[6].Width = 50;
            }

            //if (gridView.Visible)
            //    gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // to allow column resize (%colresize%)

            ssInfoSelected.Text = table.Rows.Count + "/" + _repo.Content.Count;
			return res;
		}

		private bool IsValidURL(string url)
		{
			if (url == null) return false;
			return url.StartsWith("http:") || url.StartsWith("https:") || url.StartsWith("www");
		}

		private bool IsValidFilePath(string filePath)
		{
			try
			{
				return File.Exists(filePath);
			}
			catch (Exception ex)
			{
				ex.ToString();
				return false;
			}
		}

        private void SaveRepo()
        {
            if (_repo == null) return;
            
            if (!_repo.Save())
                MessageBox.Show("Error on saving repository", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}


