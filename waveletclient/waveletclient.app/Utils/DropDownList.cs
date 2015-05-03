/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/3/2015 - Time: 8:14 PM
 */
using System;

namespace waveletclient.app.Utils
{
	
	public class DropDownList
	{
		
		public String text { get; set; }
		public String value { get; set; }
		public Object dto { get; set; }
		
		public DropDownList()
		{
		}
		
		public DropDownList(String text, String value) {
			
			this.text = text;
			this.value = value;
		}
		public DropDownList(String text, String value, Object dto) {
			
			this.text = text;
			this.value = value;
			this.dto = dto;
		}
	}
}
