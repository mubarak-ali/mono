/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/3/2015 - Time: 6:46 PM
 */
using System;
using waveletclient.dao.JsonMapper;

namespace waveletclient.dao
{
	
	public class GenericMasterDao
	{
		public String guid { get; set; }
		public String status { get; set; }
		private LogJsonMapper logJson;
		
		public void setLogJsonMapper(Object logJson) {
			
			if (logJson is LogJsonMapper) {
				
				this.logJson = logJson as LogJsonMapper;
			}
			else if (logJson is String) {
				
				this.logJson = JsonConversion.toLogJsonMapper((String) logJson);
			}
			else if (logJson == null) {
				
				this.logJson = new LogJsonMapper();
			}
			else {
				
				throw new InvalidOperationException("Invalid parameter.");
			}
		}	
		public LogJsonMapper getLogJsonMapper() {
			
			return this.logJson;
		}
	}
}
