namespace Calder1
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssInfoSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssInfoRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.tstSearch = new System.Windows.Forms.ToolStripTextBox();
            this.tsbShow10 = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenRepository = new System.Windows.Forms.ToolStripButton();
            this.tsbFavorite = new System.Windows.Forms.ToolStripButton();
            this.tscRepo = new System.Windows.Forms.ToolStripComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.ssInfoSelected,
            this.ssInfoRecord});
            this.statusStrip1.Location = new System.Drawing.Point(0, 490);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(904, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ssInfoSelected
            // 
            this.ssInfoSelected.Name = "ssInfoSelected";
            this.ssInfoSelected.Size = new System.Drawing.Size(12, 17);
            this.ssInfoSelected.Text = "-";
            // 
            // ssInfoRecord
            // 
            this.ssInfoRecord.Margin = new System.Windows.Forms.Padding(15, 3, 0, 2);
            this.ssInfoRecord.Name = "ssInfoRecord";
            this.ssInfoRecord.Size = new System.Drawing.Size(38, 17);
            this.ssInfoRecord.Text = "nome";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbSearch,
            this.tstSearch,
            this.tsbShow10,
            this.tsbOpenRepository,
            this.tsbFavorite,
            this.tscRepo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(904, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbAdd.Text = "Add record";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbSearch
            // 
            this.tsbSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(23, 22);
            this.tsbSearch.Text = "Advanced search";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // tstSearch
            // 
            this.tstSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstSearch.Name = "tstSearch";
            this.tstSearch.Size = new System.Drawing.Size(300, 25);
            this.tstSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstSearch_KeyPress);
            this.tstSearch.TextChanged += new System.EventHandler(this.tstSearch_TextChanged);
            // 
            // tsbShow10
            // 
            this.tsbShow10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbShow10.Checked = true;
            this.tsbShow10.CheckOnClick = true;
            this.tsbShow10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbShow10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShow10.Image = ((System.Drawing.Image)(resources.GetObject("tsbShow10.Image")));
            this.tsbShow10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShow10.Name = "tsbShow10";
            this.tsbShow10.Size = new System.Drawing.Size(23, 22);
            this.tsbShow10.Text = "Show last 10 records";
            this.tsbShow10.Click += new System.EventHandler(this.tsbShow10_Click);
            // 
            // tsbOpenRepository
            // 
            this.tsbOpenRepository.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenRepository.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenRepository.Image")));
            this.tsbOpenRepository.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenRepository.Name = "tsbOpenRepository";
            this.tsbOpenRepository.Size = new System.Drawing.Size(23, 22);
            this.tsbOpenRepository.Text = "Open repository";
            this.tsbOpenRepository.Click += new System.EventHandler(this.tsbOpenRepository_Click);
            // 
            // tsbFavorite
            // 
            this.tsbFavorite.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbFavorite.CheckOnClick = true;
            this.tsbFavorite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFavorite.Image = ((System.Drawing.Image)(resources.GetObject("tsbFavorite.Image")));
            this.tsbFavorite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFavorite.Name = "tsbFavorite";
            this.tsbFavorite.Size = new System.Drawing.Size(23, 22);
            this.tsbFavorite.Text = "Show favorite records";
            this.tsbFavorite.ToolTipText = "Favorite (CTRL+F)";
            this.tsbFavorite.Click += new System.EventHandler(this.tsbFavorite_Click);
            // 
            // tscRepo
            // 
            this.tscRepo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscRepo.Name = "tscRepo";
            this.tscRepo.Size = new System.Drawing.Size(400, 25);
            this.tscRepo.ToolTipText = "Repositories (F4)";
            this.tscRepo.SelectedIndexChanged += new System.EventHandler(this.tscRepo_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panel1.Size = new System.Drawing.Size(904, 465);
            this.panel1.TabIndex = 2;
            // 
            // gridView
            // 
            this.gridView.AllowDrop = true;
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridView.Location = new System.Drawing.Point(5, 0);
            this.gridView.Name = "gridView";
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.Size = new System.Drawing.Size(894, 465);
            this.gridView.TabIndex = 0;
            this.gridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellDoubleClick);
            this.gridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_RowEnter);
            this.gridView.VisibleChanged += new System.EventHandler(this.gridView_VisibleChanged);
            this.gridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.gridView_DragDrop);
            this.gridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.gridView_DragEnter);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            this.gridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridView_KeyPress);
            this.gridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseClick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Calder1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbOpenRepository;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView gridView;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		private System.Windows.Forms.ToolStripButton tsbAdd;
		private System.Windows.Forms.ToolStripButton tsbSearch;
		private System.Windows.Forms.ToolStripButton tsbFavorite;
        private System.Windows.Forms.ToolStripStatusLabel ssInfoRecord;
		private System.Windows.Forms.ToolStripComboBox tscRepo;
		private System.Windows.Forms.ToolStripStatusLabel ssInfoSelected;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripTextBox tstSearch;
        private System.Windows.Forms.ToolStripButton tsbShow10;
    }
}

