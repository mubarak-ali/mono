/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 11:11 AM
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using Newtonsoft.Json;
using waveletclient.app.Enum;
using waveletclient.app.Model;
using waveletclient.app.Session;
using waveletclient.app.Utils;
using waveletclient.dao;

namespace waveletclient.app
{
	/// <summary>
	/// Description of frmDashboard.
	/// </summary>
	public partial class frmDashboard : Form
	{
		public frmDashboard()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		}
		
		void FrmDashboardLoad(object sender, EventArgs e)
		{
			
			
		}
		
		void BtnCreateCompanyClick(object sender, EventArgs e)
		{
			CreateCompany();
		}
		
		#region Function for testing rest call to create a company.
		private void CreateCompany() {
			
			CompanyDao dao = new CompanyDao();
			dao.guid = Guid.NewGuid().ToString().ToUpper();
			dao.abbreviation = "MUB_TEST";
			dao.name = "Mubarak_TEST";
			dao.code = "TBH";
			dao.status = "A";
			dao.currencyCode = "MYY";
			dao.description = "This is for spring.net testing...";
			
			RequestMessage reqMsg = new RequestMessage();
			reqMsg.type = AppMessageEventEnum.EnumEventType.CREATE_COMPANY;
			reqMsg.documentJson = JsonConvert.SerializeObject(dao);
			
			Boolean send = RestAPI.sendPOST("/wavelet-ws/rest/createmessage", reqMsg);
			
			if (send) {
				
				MessageBox.Show("company created!");
			}
		}
		#endregion
		
	}
}
