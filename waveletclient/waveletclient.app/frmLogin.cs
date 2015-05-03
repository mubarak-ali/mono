/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 10:13 AM
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Newtonsoft.Json;
using waveletclient.app.Criteria;
using waveletclient.app.Model;
using waveletclient.app.Utils;
using waveletclient.app.Session;
using waveletclient.dao;
using waveletclient.dto;

namespace waveletclient.app
{
	
	public partial class frmLogin : Form
	{
		
		const string GET_USERS = "/wavelet-ws/v1/users/getUsers";
		const string GET_GROUPS = "/wavelet-ws/v1/users/getGroups";
		const string GET_LNK_GROUP_LOGIN = "/wavelet-ws/v1/users/getLoginGroupLinks";
		const string GET_LNK_GROUP_PERM = "/wavelet-ws/v1/users/getGroupPermLinks";
		const string GET_PERM = "/wavelet-ws/v1/users/getPermissions";
		
		public frmLogin()
		{
			InitializeComponent();	
		}
		
		void BtnLoginClick(object sender, EventArgs e)
		{
			Boolean validate = false;
			UsersCriteria criteria = new UsersCriteria();
			criteria.username = txtUsername.Text;
			ResponseMessage users = RestAPI.get(GET_USERS, criteria);
			List<UsersDto> usersDto = JsonConvert.DeserializeObject<List<UsersDto>>(users.dataJson);
			
			List<AppLoginDao> user = new List<AppLoginDao>();
			foreach (var dto in usersDto) {
				
				AppLoginDao dao = new AppLoginDao();
				dao = dto.appLoginDao;
				user.Add(dao);
			}
			
			if (user.Count > 1) {
				
				validate = false;
			}
			else if (user.Count < 0) {
				
				criteria = new UsersCriteria();
				criteria.email = txtUsername.Text;
				ResponseMessage userEmail = RestAPI.get(GET_USERS, criteria);
				usersDto = new List<UsersDto>();
				usersDto = JsonConvert.DeserializeObject<List<UsersDto>>(users.dataJson);
				
				List<AppLoginDao> userDao = new List<AppLoginDao>();
				foreach (var dto in usersDto) {
					
					AppLoginDao dao = new AppLoginDao();
					dao = dto.appLoginDao;
					userDao.Add(dao);
				}
				
				if (userDao.Count < 0) {
					
					validate = false;
				}
				else if (userDao.Count > 1) {
					
					validate = false;
				}
				else if (userDao.Count == 1) {
					
					validate = Authentication(usersDto);
				}
			}
			else if (user.Count == 1) {
				
				validate = Authentication(usersDto);
			}
			
			if (validate == true) {
				
				fmMain mainForm = new fmMain();
				this.Hide();
				mainForm.Show();
			}
			else {
				
				MessageBox.Show("The user credentials are not correct, please try again.");
			}
			
		}
		
		#region Authentication function.
		private Boolean Authentication(List<UsersDto> usersDto) {
			
			Boolean validate = false;
			AppLoginDao user = new AppLoginDao();
			
			foreach (var dto in usersDto) {
				
				List<String> permissions = new List<String>();
				List<UsersDto> dtoList = new List<UsersDto>();
				user = dto.appLoginDao;
				if (user.status != "I") {
					
					SystemSession.user = user.username;
					SystemSession.userGuid = user.guid;
					
					UsersCriteria criteria = new UsersCriteria();
					criteria.appMasterLoginToGroupUserGuid = dto.appLoginDao.guid;
					ResponseMessage msgLnkLgnGrp = RestAPI.get(GET_LNK_GROUP_LOGIN, criteria);
					if (msgLnkLgnGrp != null) {
						
						dtoList = JsonConvert.DeserializeObject<List<UsersDto>>(msgLnkLgnGrp.dataJson);
						List<AppMasterLinkLoginToGroupDao> loginToGroup = new List<AppMasterLinkLoginToGroupDao>();
						
						foreach (var dtolnklgnGrp in dtoList) {
							
							loginToGroup.Add(dtolnklgnGrp.appMasterLinkLoginToGroupDao);
							
							#region to get the groups and add the group name in permission list.
							criteria = new UsersCriteria();
							criteria.groupGuid = dtolnklgnGrp.appMasterLinkLoginToGroupDao.appGroupGuid;
							ResponseMessage msgGroup = RestAPI.get(GET_GROUPS, criteria);
							if (msgGroup != null) {
								
								List<UsersDto> dtoListGroup = new List<UsersDto>();
								dtoListGroup = JsonConvert.DeserializeObject<List<UsersDto>>(msgGroup.dataJson);
								foreach (var groupDto in dtoListGroup) {
									
									permissions.Add(groupDto.appMasterGroupDao.name);
								}
							}
							#endregion
						}
						
						foreach (var dao in loginToGroup) { //User may have multiple groups that's why foreach loop is here.
							
							#region First get all the link group to permission records and then put all the permission guid in criteria and call for permissions.
							
							criteria = new UsersCriteria();
							criteria.appMasterGroupToPermGroupGuid = dao.appGroupGuid;
							ResponseMessage msgLnkGrpPerm = RestAPI.get(GET_LNK_GROUP_PERM, criteria);
							List<UsersDto> dtoListLnkGrpPerm = new List<UsersDto>();
							if (msgLnkGrpPerm != null) {
								
								dtoListLnkGrpPerm = JsonConvert.DeserializeObject<List<UsersDto>>(msgLnkGrpPerm.dataJson);
							}
							List<AppMasterLinkGroupPermissionDao> linkGroupPerm = new List<AppMasterLinkGroupPermissionDao>();
							if (dtoListLnkGrpPerm.Count == 1 ) {
								
								foreach (var dtoLnkGrpPerm in dtoListLnkGrpPerm) {
									
									linkGroupPerm = dtoLnkGrpPerm.appMasterLinkGroupPermissionDao;
								}
							}
							
							criteria = new UsersCriteria();
							foreach (var groupPerm in linkGroupPerm) {
								
								criteria.permissionGuidList.Add(groupPerm.appPermissionGuid);
							}
							
							List<UsersDto> dtoListPerm = new List<UsersDto>();
							ResponseMessage msgPerm = RestAPI.get(GET_PERM, criteria);
							if (msgPerm != null) {
								
								dtoListPerm = JsonConvert.DeserializeObject<List<UsersDto>>(msgPerm.dataJson);
							}
							
							List<AppConfigPermissionDao> permissionList = new List<AppConfigPermissionDao>();
							if (dtoListPerm.Count == 1) {
								
								foreach (var dtoPerm in dtoListPerm) {
									
									permissionList = dtoPerm.appConfigPermissionDao;
								}
								
								foreach (var perm in permissionList) {
									
									permissions.Add(perm.code);
								}
							}
							#endregion
						}
					}
					validate = true;
					UserSession.permissions = permissions;
					UserSession.username = user.username;
					UserSession.guid = user.guid;
				}
				else {
					
					validate = false;
				}
			}
			
			return validate;
		}
		#endregion
		
	}
}
