/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 10:26 AM
 */
using System;

namespace waveletclient.app.Utils
{
	
	public class BCryptHasing
	{
		private static String GetRandomSalt()
		{
			return BCrypt.Net.BCrypt.GenerateSalt(12);
		}

		public static String HashPassword(String password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
		}

		public static Boolean ValidatePassword(String password, String correctHash)
		{
			return BCrypt.Net.BCrypt.Verify(password, correctHash);
		}
	}
}
