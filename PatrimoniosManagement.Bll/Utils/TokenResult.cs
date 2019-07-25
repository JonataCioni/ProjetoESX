using PatrimoniosManagement.Bll.Utils.Enums;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace PatrimoniosManagement.Bll.Utils
{
	[DataContract]
	public class TokenResult
	{
		public MessageType MessageType { get; set; }
		[DataMember]
		public String MessageString { get; set; }
		[DataMember]
		public String Token { get; set; }
	}
}
