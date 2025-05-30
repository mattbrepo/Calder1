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
            this.chkKeywords = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkLabel
            // 
            this.chkLabel.AutoSize = true;
            this.chkLabel.Checked = true;
            this.chkLabel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLabel.Location = new System.Drawing.Point(16, 47);
            this.chkLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkLabel.Name = "chkLabel";
            this.chkLabel.Size = new System.Drawing.Size(61, 20);
            this.chkLabel.TabIndex = 9;
            this.chkLabel.Text = "Label";
            this.chkLabel.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(16, 15);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(496, 23);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cmdSearch
            // 
            this.cmdSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdSearch.Location = new System.Drawing.Point(521, 12);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(100, 28);
            this.cmdSearch.TabIndex = 11;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            // 
            // chkTitle
            // 
            this.chkTitle.AutoSize = true;
            this.chkTitle.Checked = true;
            this.chkTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTitle.Location = new System.Drawing.Point(121, 47);
            this.chkTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTitle.Name = "chkTitle";
            this.chkTitle.Size = new System.Drawing.Size(56, 20);
            this.chkTitle.TabIndex = 12;
            this.chkTitle.Text = "Title";
            this.chkTitle.UseVisualStyleBackColor = true;
            // 
            // chkURL
            // 
            this.chkURL.AutoSize = true;
            this.chkURL.Checked = true;
            this.chkURL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkURL.Location = new System.Drawing.Point(219, 47);
            this.chkURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkURL.Name = "chkURL";
            this.chkURL.Size = new System.Drawing.Size(79, 20);
            this.chkURL.TabIndex = 13;
            this.chkURL.Text = "File/URL";
            this.chkURL.UseVisualStyleBackColor = true;
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(16, 106);
            this.chkMatchCase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(104, 20);
            this.chkMatchCase.TabIndex = 14;
            this.chkMatchCase.Text = "Match case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // chkFavorite
            // 
            this.chkFavorite.AutoSize = true;
            this.chkFavorite.Location = new System.Drawing.Point(16, 75);
            this.chkFavorite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFavorite.Name = "chkFavorite";
            this.chkFavorite.Size = new System.Drawing.Size(80, 20);
            this.chkFavorite.TabIndex = 15;
            this.chkFavorite.Text = "Favorite";
            this.chkFavorite.UseVisualStyleBackColor = true;
            // 
            // cmdReset
            // 
            this.cmdReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdReset.Location = new System.Drawing.Point(523, 48);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(100, 28);
            this.cmdReset.TabIndex = 16;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            // 
            // chkKeywords
            // 
            this.chkKeywords.AutoSize = true;
            this.chkKeywords.Checked = true;
            this.chkKeywords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeywords.Location = new System.Drawing.Point(343, 47);
            this.chkKeywords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkKeywords.Name = "chkKeywords";
            this.chkKeywords.Size = new System.Drawing.Size(90, 20);
            this.chkKeywords.TabIndex = 17;
            this.chkKeywords.Text = "Keywords";
            this.chkKeywords.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 142);
            this.Controls.Add(this.chkKeywords);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.chkFavorite);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.chkURL);
            this.Controls.Add(this.chkTitle);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.chkLabel);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.CheckBox chkKeywords;
    }
}