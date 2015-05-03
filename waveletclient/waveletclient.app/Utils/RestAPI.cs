/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 3:18 AM
 */
using System;
using Spring.Http;
using Spring.Rest.Client;
using waveletclient.app.Config;
using waveletclient.dao.JsonMapper;
using waveletclient.app.Model;
using waveletclient.app.Session;

namespace waveletclient.app.Utils
{
	public class RestAPI
	{
		static RestTemplateConfig config = new RestTemplateConfig();
		static IRestOperations restTemplate = config.MyRestClient();
		
		public static ResponseMessage get<T>( string service, T criteria )
		{
			var msg = new ResponseMessage();
			var responseEntity = new HttpEntity(criteria);
			
			HttpResponseMessage<ResponseMessage> response = restTemplate.Exchange<ResponseMessage>(service, HttpMethod.POST, responseEntity);
			msg = response.Body;
			return msg;
		}

		public static Boolean sendPOST(String service, RequestMessage reqMsg)
		{
			reqMsg.guid = Guid.NewGuid().ToString();
			
			RemoteUserProfileJsonMapper profileJson = new RemoteUserProfileJsonMapper();
			if (SystemSession.userGuid != "") {
				
				profileJson.userGuid = SystemSession.userGuid;
				reqMsg.remoteGuidUser = SystemSession.userGuid;
			}
			if (SystemSession.companyGuid != "") {
				
				profileJson.companyGuid = SystemSession.companyGuid;
			}
			if (SystemSession.systemId != "") {
				
				profileJson.system = SystemSession.systemId;
			}
			
			reqMsg.setRemoteUserProfileJson(profileJson);
			
			var responseEntity = new HttpEntity(reqMsg);
			HttpResponseMessage<RequestMessage> response = restTemplate.Exchange<RequestMessage>(service, HttpMethod.POST, responseEntity);
			
			if (response.StatusCode.Equals("200")) {
				
				return true;
			}
			else {
				
				return false;
			}
		}
		
	}
}
