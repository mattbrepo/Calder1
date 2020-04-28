namespace Calder1
{
	partial class RecordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.cmbAuthor = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.chkFavorite = new System.Windows.Forms.CheckBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optBookmark = new System.Windows.Forms.RadioButton();
            this.optDoc = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.listViewLabels = new System.Windows.Forms.ListView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cmdSelectAll = new System.Windows.Forms.Button();
            this.cmdAddLabel = new System.Windows.Forms.Button();
            this.chkOnlySelectedLabel = new System.Windows.Forms.CheckBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblLabelFilter = new System.Windows.Forms.Label();
            this.cmdOk = new System.Windows.Forms.Button();
            this.panelKeyWords = new System.Windows.Forms.Panel();
            this.txtKeyWords = new System.Windows.Forms.TextBox();
            this.panelKWLabel = new System.Windows.Forms.Panel();
            this.lblKeywords = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelKeyWords.SuspendLayout();
            this.panelKWLabel.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(666, 439);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtDate);
            this.panel3.Controls.Add(this.lblDate);
            this.panel3.Controls.Add(this.lblAuthor);
            this.panel3.Controls.Add(this.cmbAuthor);
            this.panel3.Controls.Add(this.lblLanguage);
            this.panel3.Controls.Add(this.chkFavorite);
            this.panel3.Controls.Add(this.cmbLanguage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(660, 31);
            this.panel3.TabIndex = 8;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(556, 5);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(93, 20);
            this.txtDate.TabIndex = 13;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(520, 8);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "Date";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(310, 9);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(38, 13);
            this.lblAuthor.TabIndex = 11;
            this.lblAuthor.Text = "Author";
            // 
            // cmbAuthor
            // 
            this.cmbAuthor.FormattingEnabled = true;
            this.cmbAuthor.Location = new System.Drawing.Point(354, 6);
            this.cmbAuthor.Name = "cmbAuthor";
            this.cmbAuthor.Size = new System.Drawing.Size(121, 21);
            this.cmbAuthor.TabIndex = 10;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(9, 6);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(55, 13);
            this.lblLanguage.TabIndex = 9;
            this.lblLanguage.Text = "Language";
            // 
            // chkFavorite
            // 
            this.chkFavorite.AutoSize = true;
            this.chkFavorite.Location = new System.Drawing.Point(224, 5);
            this.chkFavorite.Name = "chkFavorite";
            this.chkFavorite.Size = new System.Drawing.Size(64, 17);
            this.chkFavorite.TabIndex = 8;
            this.chkFavorite.Text = "Favorite";
            this.chkFavorite.UseVisualStyleBackColor = true;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(70, 3);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 21);
            this.cmbLanguage.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdBrowse);
            this.panel2.Controls.Add(this.txtURL);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 31);
            this.panel2.TabIndex = 5;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(582, 5);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowse.TabIndex = 1;
            this.cmdBrowse.Text = "Browse";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(12, 5);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(568, 20);
            this.txtURL.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.optBookmark);
            this.panel1.Controls.Add(this.optDoc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 31);
            this.panel1.TabIndex = 2;
            // 
            // optBookmark
            // 
            this.optBookmark.AutoSize = true;
            this.optBookmark.Location = new System.Drawing.Point(259, 9);
            this.optBookmark.Name = "optBookmark";
            this.optBookmark.Size = new System.Drawing.Size(73, 17);
            this.optBookmark.TabIndex = 1;
            this.optBookmark.TabStop = true;
            this.optBookmark.Text = "Bookmark";
            this.optBookmark.UseVisualStyleBackColor = true;
            this.optBookmark.CheckedChanged += new System.EventHandler(this.optBookmark_CheckedChanged);
            // 
            // optDoc
            // 
            this.optDoc.AutoSize = true;
            this.optDoc.Location = new System.Drawing.Point(12, 9);
            this.optDoc.Name = "optDoc";
            this.optDoc.Size = new System.Drawing.Size(45, 17);
            this.optDoc.TabIndex = 0;
            this.optDoc.TabStop = true;
            this.optDoc.Text = "Doc";
            this.optDoc.UseVisualStyleBackColor = true;
            this.optDoc.CheckedChanged += new System.EventHandler(this.optDoc_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtTitle);
            this.panel5.Controls.Add(this.lblTitle);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 114);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(660, 25);
            this.panel5.TabIndex = 12;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(47, 4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(602, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(9, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.listViewLabels);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 145);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(660, 291);
            this.panel6.TabIndex = 13;
            // 
            // listViewLabels
            // 
            this.listViewLabels.CheckBoxes = true;
            this.listViewLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLabels.GridLines = true;
            this.listViewLabels.Location = new System.Drawing.Point(0, 31);
            this.listViewLabels.Name = "listViewLabels";
            this.listViewLabels.Size = new System.Drawing.Size(658, 258);
            this.listViewLabels.TabIndex = 13;
            this.listViewLabels.UseCompatibleStateImageBehavior = false;
            this.listViewLabels.View = System.Windows.Forms.View.SmallIcon;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cmdSelectAll);
            this.panel7.Controls.Add(this.cmdAddLabel);
            this.panel7.Controls.Add(this.chkOnlySelectedLabel);
            this.panel7.Controls.Add(this.txtFilter);
            this.panel7.Controls.Add(this.lblLabelFilter);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(658, 31);
            this.panel7.TabIndex = 12;
            // 
            // cmdSelectAll
            // 
            this.cmdSelectAll.Location = new System.Drawing.Point(487, 2);
            this.cmdSelectAll.Name = "cmdSelectAll";
            this.cmdSelectAll.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectAll.TabIndex = 11;
            this.cmdSelectAll.Text = "Select all";
            this.cmdSelectAll.UseVisualStyleBackColor = true;
            this.cmdSelectAll.Click += new System.EventHandler(this.cmdSelectAll_Click);
            // 
            // cmdAddLabel
            // 
            this.cmdAddLabel.Location = new System.Drawing.Point(581, 2);
            this.cmdAddLabel.Name = "cmdAddLabel";
            this.cmdAddLabel.Size = new System.Drawing.Size(75, 23);
            this.cmdAddLabel.TabIndex = 10;
            this.cmdAddLabel.Text = "Add label";
            this.cmdAddLabel.UseVisualStyleBackColor = true;
            this.cmdAddLabel.Click += new System.EventHandler(this.cmdAddLabel_Click);
            // 
            // chkOnlySelectedLabel
            // 
            this.chkOnlySelectedLabel.AutoSize = true;
            this.chkOnlySelectedLabel.Location = new System.Drawing.Point(259, 7);
            this.chkOnlySelectedLabel.Name = "chkOnlySelectedLabel";
            this.chkOnlySelectedLabel.Size = new System.Drawing.Size(122, 17);
            this.chkOnlySelectedLabel.TabIndex = 9;
            this.chkOnlySelectedLabel.Text = "Show Only Selected";
            this.chkOnlySelectedLabel.UseVisualStyleBackColor = true;
            this.chkOnlySelectedLabel.CheckedChanged += new System.EventHandler(this.chkOnlySelectedLabel_CheckedChanged);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(47, 5);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(131, 20);
            this.txtFilter.TabIndex = 3;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblLabelFilter
            // 
            this.lblLabelFilter.AutoSize = true;
            this.lblLabelFilter.Location = new System.Drawing.Point(9, 8);
            this.lblLabelFilter.Name = "lblLabelFilter";
            this.lblLabelFilter.Size = new System.Drawing.Size(29, 13);
            this.lblLabelFilter.TabIndex = 2;
            this.lblLabelFilter.Text = "Filter";
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(14, 5);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 0;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // panelKeyWords
            // 
            this.panelKeyWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKeyWords.Controls.Add(this.txtKeyWords);
            this.panelKeyWords.Controls.Add(this.panelKWLabel);
            this.panelKeyWords.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelKeyWords.Location = new System.Drawing.Point(666, 0);
            this.panelKeyWords.Name = "panelKeyWords";
            this.panelKeyWords.Size = new System.Drawing.Size(200, 439);
            this.panelKeyWords.TabIndex = 5;
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeyWords.Location = new System.Drawing.Point(0, 21);
            this.txtKeyWords.Multiline = true;
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(198, 416);
            this.txtKeyWords.TabIndex = 0;
            // 
            // panelKWLabel
            // 
            this.panelKWLabel.Controls.Add(this.lblKeywords);
            this.panelKWLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKWLabel.Location = new System.Drawing.Point(0, 0);
            this.panelKWLabel.Name = "panelKWLabel";
            this.panelKWLabel.Size = new System.Drawing.Size(198, 21);
            this.panelKWLabel.TabIndex = 13;
            // 
            // lblKeywords
            // 
            this.lblKeywords.AutoSize = true;
            this.lblKeywords.Location = new System.Drawing.Point(0, 3);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(53, 13);
            this.lblKeywords.TabIndex = 13;
            this.lblKeywords.Text = "Keywords";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.cmdOk);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 439);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(866, 38);
            this.panel8.TabIndex = 6;
            // 
            // RecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 477);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelKeyWords);
            this.Controls.Add(this.panel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panelKeyWords.ResumeLayout(false);
            this.panelKeyWords.PerformLayout();
            this.panelKWLabel.ResumeLayout(false);
            this.panelKWLabel.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton optBookmark;
		private System.Windows.Forms.RadioButton optDoc;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button cmdBrowse;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ComboBox cmbLanguage;
		private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.CheckBox chkFavorite;
		private System.Windows.Forms.Button cmdOk;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.Label lblLabelFilter;
		private System.Windows.Forms.ListView listViewLabels;
		private System.Windows.Forms.CheckBox chkOnlySelectedLabel;
		private System.Windows.Forms.Label lblAuthor;
		private System.Windows.Forms.ComboBox cmbAuthor;
		private System.Windows.Forms.Button cmdAddLabel;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panelKeyWords;
        private System.Windows.Forms.TextBox txtKeyWords;
        private System.Windows.Forms.Panel panelKWLabel;
        private System.Windows.Forms.Label lblKeywords;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button cmdSelectAll;


	}
}