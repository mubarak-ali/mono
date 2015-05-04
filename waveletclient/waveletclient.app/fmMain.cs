/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 10:43 AM
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Newtonsoft.Json;
using waveletclient.app.Criteria;
using waveletclient.app.Model;
using waveletclient.app.Session;
using waveletclient.app.Utils;
using waveletclient.app.Enum;
using waveletclient.dao;
using waveletclient.dao.JsonMapper;
using waveletclient.dto;

namespace waveletclient.app
{

	public partial class fmMain : Form
	{
		const String COMPANY_URL = "/wavelet-ws/v1/company/get";
		
		public fmMain()
		{
			InitializeComponent();
		}
		
		void FmMainLoad(object sender, EventArgs e)
		{
			lblUsername.Text = "Welcome " + UserSession.username;
			ddlSystem.SelectedText = "GST";
			
			CompanyCriteria criteria = new CompanyCriteria();
			criteria.GetAll = true;
			ResponseMessage users = RestAPI.get(COMPANY_URL, criteria);
			if (users != null) {
				
				List<CompanyDto> companyDto = JsonConvert.DeserializeObject<List<CompanyDto>>(users.dataJson);
				List<DropDownList> dropDownList = new List<DropDownList>();
				foreach (var dto in companyDto) {
					
					CompanyDao dao = new CompanyDao();
					dao = dto.companyDao;
					dropDownList.Add(new DropDownList( dao.code + " - " + dao.name, dao.guid ));
				}
				
				ddlCompany.DataSource = dropDownList;
				ddlCompany.ValueMember = "value";
				ddlCompany.DisplayMember = "text";
			}
			
		}
		
		void BtnNextClick(object sender, EventArgs e)
		{
			DropDownList ddl = (DropDownList) ddlCompany.SelectedItem;
			
			SystemSession.company = ddl.text;
			SystemSession.companyGuid = ddl.value;
			SystemSession.systemId = ddlSystem.Text;
			
			CreateCompany();
			frmDashboard dashboard = new frmDashboard();
			this.Hide();
			dashboard.Show();
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
			reqMsg.remoteTimeCreate = DateTime.Now;
			
			Boolean send = RestAPI.sendPOST("/wavelet-ws/rest/createmessage", reqMsg);
		}
		#endregion
	}
}
