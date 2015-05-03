/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 3:08 AM
 */
using System;
using System.Collections.Generic;
using waveletclient.dao;

namespace waveletclient.dto
{
	
	public class UsersDto
	{
		public AppLoginDao appLoginDao { get; set; }
		public AppMasterGroupDao appMasterGroupDao { get; set; }
		public AppMasterLinkLoginToGroupDao appMasterLinkLoginToGroupDao { get; set; }
		public List<AppMasterLinkGroupPermissionDao> appMasterLinkGroupPermissionDao { get; set; }
		public List<AppConfigPermissionDao> appConfigPermissionDao { get; set; }
		
		public UsersDto()
		{
			this.appLoginDao = new AppLoginDao();
			this.appMasterGroupDao = new AppMasterGroupDao();
			this.appMasterLinkLoginToGroupDao = new AppMasterLinkLoginToGroupDao();
			this.appMasterLinkGroupPermissionDao = new List<AppMasterLinkGroupPermissionDao>();
			this.appConfigPermissionDao = new List<AppConfigPermissionDao>();
		}
	}
}
