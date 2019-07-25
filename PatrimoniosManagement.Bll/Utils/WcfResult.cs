using System;
using System.Runtime.Serialization;

namespace PatrimoniosManagement.Bll.Utils
{
	[DataContract]
	public class WcfResult<T>
	{
		[DataMember]
		public TokenResult TokenResult { get; set; }
		[DataMember]
		public T DataResult { get; set; }
		[DataMember]
		public String ErrorMessage { get; set; }

		private BllToken bllToken;

		public WcfResult(String token)
		{
			this.bllToken = new BllToken();
			this.TokenResult = this.bllToken.ValidToken(token);
		}
	}
}