using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Calder1
{
	public partial class RecordForm : Form
	{
        #region const
        const string LABEL_SELECT_ALL = "Select all";
        const string LABEL_DESELECT_ALL = "Deselect all"; 
        #endregion

        #region field
        private Calder1Repository _repo;
        private Calder1Record _record;
        private Calder1Record _lastSelectedRecord;
        private List<ListViewItem> _labels;
        private bool _clearing;
		#endregion

		#region ctor
		public RecordForm()
		{
			InitializeComponent();
            _clearing = false;
        } 
		#endregion

		#region public function
		internal void SetRepository(Calder1Repository repo, Calder1Record record, Calder1Record lastSelectedRecord)
		{
            _repo = repo;
            _record = record;
            _lastSelectedRecord = lastSelectedRecord;

            ClearUI();

            cmdSelectAll.Text = LABEL_SELECT_ALL;
            cmdCopyLabelsFromSelRec.Enabled = (_lastSelectedRecord != null);
            cmbLanguage.Items.AddRange(_repo.Content.Select(x => x.Language).Where(x => x != "").Distinct().ToArray<string>());
			cmbAuthor.Items.AddRange(_repo.Content.Select(x => x.Author).Where(x => x != "").Distinct().ToArray<string>());

			string[] labels = _repo.Content.SelectMany(x => x.Labels.Split(' ')).Distinct().Where(x => !string.IsNullOrEmpty(x)).OrderBy(x => x).ToArray();
			_labels = labels.Select(x => new ListViewItem(x)).ToList();
			
			listViewLabels.Items.AddRange(_labels.ToArray());

			this.Text = "";
			if (record == null)
			{
				cmbAuthor.SelectedIndex = 0;
				cmbLanguage.SelectedIndex = 0;
                txtDate.Text = DateTime.Now.ToString(Calder1Repository.DATETIME_FORMAT);
				return;
			}

            txtDate.Text = record.Date;
			if (record.Kind == Calder1Repository.KIND_DOC)
			{
				optDoc.Checked = true;
				txtURL.Text = _repo.GetRecordPath(record);
				this.Text = Path.GetFileName(record.URL);
			}
			else
			{
				optBookmark.Checked = true;
				txtURL.Text = record.URL;
				this.Text = record.URL;
			}

			List<string> recLabels = record.Labels.Split(' ').ToList();
			for (int i = 0; i < recLabels.Count; i++)
			{
				int index = _labels.FindIndex(x => x.Text == recLabels[i]);
				if (index < 0) continue; //it shouldn't happen
				_labels[index].Checked = true;
			}

            chkFavorite.Checked = (record.Favorite == Calder1Repository.FAVORITE);
			cmbLanguage.Text = record.Language;
			cmbAuthor.Text = record.Author;
			txtTitle.Text = record.Title;
			txtFilter.Text = "";
            txtKeyWords.Text = record.Keywords.Replace(Calder1Repository.KW_NEW_LINE, "\r\n"); // convert newlines
		}

		/// <summary>
		/// Set a filePath in the UI
		/// </summary>
		/// <param name="filePath"></param>
		internal void SetFilePath(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				txtURL.Text = "";
			}
			else
			{
				txtURL.Text = filePath;
				this.Text = Path.GetFileName(filePath);
				txtTitle.Text = Path.GetFileNameWithoutExtension(filePath).Replace("_", " ");
			}
			optDoc.Checked = true;
		}

		internal void SetURL(string filePathOrURL)
		{
			txtURL.Text = filePathOrURL;
			optBookmark.Checked = true;
		}

		/// <summary>
		/// Gets the document filepath from UI
		/// </summary>
		/// <returns></returns>
		internal string GetFilePath()
		{
			return txtURL.Text;
		}

		/// <summary>
		/// Gets a Calder1Record from UI
		/// </summary>
		/// <returns></returns>
		internal Calder1Record GetRecord()
		{
			Calder1Record res = new Calder1Record();
			if (optDoc.Checked)
			{
				res.Kind = Calder1Repository.KIND_DOC;
				res.URL = Path.GetFileName(txtURL.Text.Trim());
			}
			else
			{
				res.Kind = Calder1Repository.KIND_BOOKMARK;
				res.URL = txtURL.Text.Trim();
			}

			res.Title = txtTitle.Text.Trim();
            res.Keywords = txtKeyWords.Text.Trim().Replace("\r\n", Calder1Repository.KW_NEW_LINE); // convert it back
            res.Date = txtDate.Text;
			res.Author = cmbAuthor.Text;
			res.Language = cmbLanguage.Text;

			res.Labels = "";
			for (int i = 0; i < _labels.Count; i++)
			{
				if (_labels[i].Checked)
					res.Labels += _labels[i].Text + " ";
			}
			res.Labels = res.Labels.Trim();

			res.Favorite = chkFavorite.Checked ? Calder1Repository.FAVORITE : "";
			return res;
		}

		private void ClearUI()
		{
            _clearing = true;
            cmbLanguage.Items.Clear();
            cmbAuthor.Items.Clear();
            listViewLabels.Clear();
            listViewLabels.Items.Clear();
            chkOnlySelectedLabel.Checked = false;
			chkFavorite.Checked = false;
			this.Text = "";
			txtTitle.Text = "";
            txtFilter.Text = "";
            txtKeyWords.Text = "";
            txtDate.Text = "";
            _clearing = false;
        }

		#endregion

		#region event

		private void cmdOk_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtURL.Text.Trim()))
			{
				MessageBox.Show("URL empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (txtURL.Text.Contains(Calder1Repository.CSV_SEP))
			{
				MessageBox.Show("URL not valid (" + Calder1Repository.CSV_SEP + ")", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
			{
				MessageBox.Show("Title empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (txtTitle.Text.Contains(Calder1Repository.CSV_SEP))
			{
				MessageBox.Show("Title not valid (" + Calder1Repository.CSV_SEP + ")", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

            DateTime dt;
            if (!DateTime.TryParseExact(txtDate.Text, Calder1Repository.DATETIME_FORMAT, null, System.Globalization.DateTimeStyles.None, out dt))
            {
                MessageBox.Show("Date not valid ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void cmdBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				return;

			txtURL.Text = ofd.FileName;
		}

		private void optDoc_CheckedChanged(object sender, EventArgs e)
		{
			cmdBrowse.Visible = optDoc.Checked;
		}

		private void optBookmark_CheckedChanged(object sender, EventArgs e)
		{
			cmdBrowse.Visible = optDoc.Checked;
		}

		private void txtFilter_TextChanged(object sender, EventArgs e)
		{
            if (_clearing)
                return;
			UpdateUI();
		}

		private void chkOnlySelectedLabel_CheckedChanged(object sender, EventArgs e)
		{
            if (_clearing)
                return;
            UpdateUI();
		}

		private void cmdAddLabel_Click(object sender, EventArgs e)
		{
			InputForm labelForm = new InputForm();
			labelForm.SetInput("New label: ", "");
			if (labelForm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
			string label = labelForm.GetInputText();

			if (label.Contains(Calder1Repository.CSV_SEP))
			{
				MessageBox.Show("Label not valid (" + Calder1Repository.CSV_SEP + ")", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (_labels.Select(x => x.Text).Contains(label))
			{
				MessageBox.Show("Label already present", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_labels.Add(new ListViewItem(label) { Checked = true });
			UpdateUI();
		}

        private void cmdSelectAll_Click(object sender, EventArgs e)
        {
            if (cmdSelectAll.Text == LABEL_SELECT_ALL)
            {
                cmdSelectAll.Text = LABEL_DESELECT_ALL;
                foreach (ListViewItem item in listViewLabels.Items)
                    item.Checked = true;
            }
            else
            {
                cmdSelectAll.Text = LABEL_SELECT_ALL;
                foreach (ListViewItem item in listViewLabels.Items)
                    item.Checked = false;
            }
        }

        private void cmdCopyLabelsFromSelRec_Click(object sender, EventArgs e)
        {
            if (_lastSelectedRecord != null)
            {
                txtFilter.Text = _lastSelectedRecord.Labels;
            }
        }

        private void cmdCopyTitleFromSelRec_Click(object sender, EventArgs e)
        {
            if (_lastSelectedRecord != null)
            {
                txtTitle.Text = _lastSelectedRecord.Title;
                cmbLanguage.SelectedIndex = cmbLanguage.Items.IndexOf(_lastSelectedRecord.Language);
            }
        }

        private void cmdCopyKeyWordsFromSelRec_Click(object sender, EventArgs e)
        {
            if (_lastSelectedRecord != null)
            {
                txtKeyWords.Text = _lastSelectedRecord.Keywords;
            }
        }

        #endregion

        #region private function
        private void UpdateUI()
		{
			listViewLabels.Items.Clear();

            string[] filterLabels = txtFilter.Text.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i < _labels.Count; i++)
			{
				if (listViewLabels.Items.Contains(_labels[i]))
					continue;

				if (filterLabels.Length == 0)
				{
					if (!chkOnlySelectedLabel.Checked || _labels[i].Checked)
						listViewLabels.Items.Add(_labels[i]);
				}
				else
				{
					for (int j = 0; j < filterLabels.Length; j++)
					{
						if (_labels[i].Text.ToLower().Contains(filterLabels[j]) && (!chkOnlySelectedLabel.Checked || _labels[i].Checked))
						{
							listViewLabels.Items.Add(_labels[i]);
							break;
						}
					}
				}
			}
		}

        #endregion

    }
}
