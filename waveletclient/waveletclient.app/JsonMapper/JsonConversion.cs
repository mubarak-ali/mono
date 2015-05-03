/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 12:47 PM
 */
using System;
using Newtonsoft.Json;
using waveletclient.app.JsonMapper;

namespace waveletclient.app.JsonMapper
{
	
	public class JsonConversion
	{
		
		public static RemoteUserProfileJsonMapper toRemoteUserProfileJson(String profileJson)
		{
			RemoteUserProfileJsonMapper profile = new RemoteUserProfileJsonMapper();
			if (profileJson != null) {
				
				if (profileJson == "{}" && profileJson == " " && profileJson == "" && profileJson == "[]") {
					
					profile = new RemoteUserProfileJsonMapper();
				}
				else {
					
					profile = JsonConvert.DeserializeObject<RemoteUserProfileJsonMapper>(profileJson);
				}
			}
			
			return profile;
		}
	}
}
