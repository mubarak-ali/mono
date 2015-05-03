/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 3:10 AM
 */
using System;
using System.Collections.Generic;

namespace waveletclient.app.Criteria
{
	
	public class UsersCriteria
	{
		public Boolean GetAll { get; set; }
		public String userGuid { get; set; }
		public String username { get; set; }
		public String email { get; set; }
		public String appMasterLoginToGroupUserGuid { get; set; }
		public String appMasterGroupToPermGroupGuid { get; set; }
		public String permissionGuid { get; set; }
		public String userStatus { get; set; }
	
		public List<String> permissionGuidList { get; set; }
	
		//Criteria to search in AppMasterGroup table by name.
		public String groupName { get; set; }
		public String groupGuid { get; set; }
		
		public UsersCriteria()
		{
			this.permissionGuidList = new List<String>();
		}
	}
}
