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
using waveletclient.dao;
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
			 
			 frmDashboard dashboard = new frmDashboard();
			 this.Hide();
			 dashboard.Show();
		}
	}
}
