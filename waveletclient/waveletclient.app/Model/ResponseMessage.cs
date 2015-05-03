/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 3:13 AM
 */
using System;
using Newtonsoft.Json;

namespace waveletclient.app.Model
{
	
	public class ResponseMessage
	{
		public String dataJson { get; set; }
		
		[JsonIgnore]
		public DateTime date { get; set; }
	}
}
