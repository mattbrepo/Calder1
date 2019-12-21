using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO.Pipes;

namespace Calder1
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
			if (processes.Length > 1)
			{
				NamedPipeClientStream pipeClient = new NamedPipeClientStream(MainForm.PIPE_NAME);
				pipeClient.Connect();
				pipeClient.Close();
				//MessageBox.Show("sent"); //pro-debug
				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
