/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/3/2015 - Time: 7:06 PM
 */
using System;
using waveletclient.dao.Enum;
using waveletclient.dao.Utils;

namespace waveletclient.dao.JsonMapper
{
	
	public class PropertyJsonMapper
	{
		public String guid { get; set; }
		public FieldEnum.EnumDataType dataType { get; set; }
		private Object data;
		
		public void setData(Object data) {
			
			if ( data == null )
			{
				switch ( this.dataType )
				{
					case FieldEnum.EnumDataType.STRING:
					case FieldEnum.EnumDataType.NUMERIC:
						this.data = null;
						break;
						
					case FieldEnum.EnumDataType.BOOLEAN:
						this.data = false;
						break;
				}
			}
			else if ( data is String )
			{
				switch ( this.dataType )
				{
					case FieldEnum.EnumDataType.STRING:
						this.data = data;
						break;
						
					case FieldEnum.EnumDataType.NUMERIC:
						if ( ((String) data) == "" || ((String) data) == " ")
							this.data = null;
						else
							this.data = (decimal) data;
						break;
						
					case FieldEnum.EnumDataType.BOOLEAN:
						this.data = ( (String) data ) == "true" ? true : false;
						break;
				}
			}
			else
				this.data = data;
		}
		public Object getData() {
			
			return this.data;
		}
	}
}
