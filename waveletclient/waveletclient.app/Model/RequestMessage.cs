/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 12:19 PM
 */
using System;
using waveletclient.app.Enum;
using waveletclient.app.JsonMapper;

namespace waveletclient.app.Model
{
	
	public class RequestMessage
	{
		public String guid { get; set; }
		public String triggerKey { get; set; }
		public AppMessageEventEnum.EnumEventType type { get; set; }
		public Int32 priority { get; set; }
		public String localLoginGuid { get; set; }
		public String localTimeMessage { get; set; }
		public String localTimeCreate { get; set; }
		public String localTimeUpdate { get; set; }
		public String localTimeDelete { get; set; }
		public String localStatus { get; set; }
		public String remoteIdDevice { get; set; }
		public String remoteGuidUser { get; set; }
		public String remoteIdUser { get; set; }
		public String remoteGuidMessage { get; set; }
		public String remoteTimeCreate { get; set; }
		public String remoteDocumentId { get; set; }
		public String documentJson { get; set; }
		public String remarks { get; set; }
		public String status { get; set; }
		
		private RemoteUserProfileJsonMapper remoteUserProfileJson;
		public void setRemoteUserProfileJson(Object profileJson)
		{
			
			if (profileJson is RemoteUserProfileJsonMapper) {
				
				this.remoteUserProfileJson = profileJson as RemoteUserProfileJsonMapper;
			}
			else if (profileJson is String) {
				
				profileJson = JsonConversion.toRemoteUserProfileJson((String) profileJson);
			}
			else if (profileJson == null) {
				
				this.remoteUserProfileJson = new RemoteUserProfileJsonMapper();
			}
			else {
				
				throw new InvalidOperationException("Invalid parameter.");
			}
		}
		public RemoteUserProfileJsonMapper getRemoteUserProfileJson() {
			
			return this.remoteUserProfileJson;
		}
		
		public RequestMessage()
		{
			this.priority = 0;
		}
	}
}