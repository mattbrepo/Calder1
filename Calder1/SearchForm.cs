using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calder1
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        public string GetSearchText()
        {
            return txtSearch.Text;
        }

        public bool HasFavorite()
        {
            return chkFavorite.Checked;
        }

    }
}
