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
	public partial class InputForm : Form
	{
		public InputForm()
		{
			InitializeComponent();
		}

		public void SetInput(string label, string content)
		{
			label1.Text = label;
			textBox1.Text = content;
		}

		public string GetInputText()
		{
			return textBox1.Text;
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

	}
}
