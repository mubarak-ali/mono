/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/3/2015 - Time: 6:37 PM
 */
using System;

namespace waveletclient.app.Criteria
{
	
	public class CompanyCriteria : BaseCriteria
	{
		public String guid { get; set; }
		public String code { get; set; }
		public String name { get; set; }
		public String nameEqual { get; set; }
		public String taxRegistrationId { get; set; }
		public String companyRegistrationNumber { get; set; }
		public String status { get; set; }
	}
}
