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
	public partial class RenameForm : Form
	{
		public RenameForm()
		{
			InitializeComponent();
		}

		public void SetFileName(string fileName)
		{
			textBox1.Text = fileName;
		}

		public string GetFileName()
		{
			return textBox1.Text;
		}
	}
}
