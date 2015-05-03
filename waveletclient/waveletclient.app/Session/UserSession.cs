/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 11:41 AM
 */
using System;
using System.Collections.Generic;

namespace waveletclient.app.Session
{
	
	public static class UserSession
	{
		public static String guid { get; set; }
		public static String username { get; set; }
		public static String password { get; set; }
		public static List<String> permissions { get; set; }
	}
}
