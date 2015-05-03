/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/3/2015 - Time: 6:46 PM
 */
using System;
using System.Collections.Generic;
using waveletclient.dao.JsonMapper;

namespace waveletclient.dao
{
	
	public class CompanyDao : GenericMasterDao
	{
		public String code { get; set; }
		public String name { get; set; }
		public String abbreviation { get; set; }
		public String description { get; set; }
		public String taxRegistrationId { get; set; }
		public String companyRegistrationNumber { get; set; }
		public String currencyCode { get; set; }
		public String appMasterEntityHeaderGuid { get; set; }
		private List<PropertyJsonMapper> propertyJson;
		
		public List<PropertyJsonMapper> getPropertyJson() {
			
			return this.propertyJson;
		}
		public void setPropertyJson(Object json) {
			
			if (json is List<PropertyJsonMapper>) {
				
				this.propertyJson = json as List<PropertyJsonMapper>;
			}
			else if (json is String) {
				
				this.propertyJson = JsonConversion.toPropertyJsonMapper((String) json);
			}
			else if (json == null) {
				
				this.propertyJson = new List<PropertyJsonMapper>();
			}
			else {
				
				throw new InvalidOperationException("Invalid parameter.");
			}
		}
	
	}
}
