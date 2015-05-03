/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/3/2015 - Time: 6:52 PM
 */
using System;

namespace waveletclient.dao.JsonMapper
{
	
	public class LogJsonMapper
	{
		public String createdBy { get; set; }
		public TimeSpan createdTime  { get; set; }
		public String updatedBy  { get; set; }
		public TimeSpan updatedTime  { get; set; }
	}
}
