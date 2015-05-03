/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 12:47 PM
 */
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using waveletclient.dao.JsonMapper;

namespace waveletclient.dao.JsonMapper
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
		
		public static LogJsonMapper toLogJsonMapper(String logJson)
		{
			LogJsonMapper json = new LogJsonMapper();
			if (logJson != null) {
				
				if (logJson == "{}" && logJson == " " && logJson == "" && logJson == "[]") {
					
					json = new LogJsonMapper();
				}
				else {
					
					json = JsonConvert.DeserializeObject<LogJsonMapper>(logJson);
				}
			}
			
			return json;
		}
		
		public static List<PropertyJsonMapper> toPropertyJsonMapper(String propertyJson)
		{
			List<PropertyJsonMapper> json = new List<PropertyJsonMapper>();
			if (propertyJson != null) {
				
				if (propertyJson == "{}" && propertyJson == " " && propertyJson == "" && propertyJson == "[]") {
					
					json = new List<PropertyJsonMapper>();
				}
				else {
					
					json = JsonConvert.DeserializeObject<List<PropertyJsonMapper>>(propertyJson);
				}
			}
			
			return json;
		}
		
	}
}
