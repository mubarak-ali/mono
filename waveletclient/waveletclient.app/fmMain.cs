/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 10:43 AM
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using waveletclient.app.Session;

namespace waveletclient.app
{

	public partial class fmMain : Form
	{
		
		public fmMain()
		{
			InitializeComponent();
		}
		
		void FmMainLoad(object sender, EventArgs e)
		{
			lblUsername.Text = "Welcome " + UserSession.username;
		}
	}
}
