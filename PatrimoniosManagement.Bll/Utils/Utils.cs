using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatrimoniosManagement.Bll.Utils
{
	public static class Utils
	{
		public static String GetDescriptionEnum(Object objEnumValue)
		{
			FieldInfo fi = objEnumValue.GetType().GetField(objEnumValue.ToString());
			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
			return attributes != null && attributes.Length > 0 ? attributes[0].Description : objEnumValue.ToString();
		}
	}
}
