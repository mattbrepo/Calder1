namespace Calder1
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.chkLabel = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.chkTitle = new System.Windows.Forms.CheckBox();
            this.chkURL = new System.Windows.Forms.CheckBox();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.chkFavorite = new System.Windows.Forms.CheckBox();
            this.cmdReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkLabel
            // 
            this.chkLabel.AutoSize = true;
            this.chkLabel.Checked = true;
            this.chkLabel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLabel.Location = new System.Drawing.Point(12, 38);
            this.chkLabel.Name = "chkLabel";
            this.chkLabel.Size = new System.Drawing.Size(52, 17);
            this.chkLabel.TabIndex = 9;
            this.chkLabel.Text = "Label";
            this.chkLabel.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(373, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cmdSearch
            // 
            this.cmdSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdSearch.Location = new System.Drawing.Point(391, 10);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 23);
            this.cmdSearch.TabIndex = 11;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            // 
            // chkTitle
            // 
            this.chkTitle.AutoSize = true;
            this.chkTitle.Checked = true;
            this.chkTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTitle.Location = new System.Drawing.Point(132, 38);
            this.chkTitle.Name = "chkTitle";
            this.chkTitle.Size = new System.Drawing.Size(46, 17);
            this.chkTitle.TabIndex = 12;
            this.chkTitle.Text = "Title";
            this.chkTitle.UseVisualStyleBackColor = true;
            // 
            // chkURL
            // 
            this.chkURL.AutoSize = true;
            this.chkURL.Checked = true;
            this.chkURL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkURL.Location = new System.Drawing.Point(244, 38);
            this.chkURL.Name = "chkURL";
            this.chkURL.Size = new System.Drawing.Size(69, 17);
            this.chkURL.TabIndex = 13;
            this.chkURL.Text = "File/URL";
            this.chkURL.UseVisualStyleBackColor = true;
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(132, 60);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(82, 17);
            this.chkMatchCase.TabIndex = 14;
            this.chkMatchCase.Text = "Match case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // chkFavorite
            // 
            this.chkFavorite.AutoSize = true;
            this.chkFavorite.Location = new System.Drawing.Point(12, 61);
            this.chkFavorite.Name = "chkFavorite";
            this.chkFavorite.Size = new System.Drawing.Size(64, 17);
            this.chkFavorite.TabIndex = 15;
            this.chkFavorite.Text = "Favorite";
            this.chkFavorite.UseVisualStyleBackColor = true;
            // 
            // cmdReset
            // 
            this.cmdReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdReset.Location = new System.Drawing.Point(392, 39);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 23);
            this.cmdReset.TabIndex = 16;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 89);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.chkFavorite);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.chkURL);
            this.Controls.Add(this.chkTitle);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.chkLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkLabel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.CheckBox chkTitle;
        private System.Windows.Forms.CheckBox chkURL;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private System.Windows.Forms.CheckBox chkFavorite;
        private System.Windows.Forms.Button cmdReset;
    }
}