using PatrimoniosManagement.Bll;
using PatrimoniosManagement.Bll.Utils;
using PatrimoniosManagement.WebApi.Interfaces;
using System;

namespace PatrimoniosManagement.WebApi
{
	public class WcfToken : IWcfToken
	{
		public TokenResult Token(String Email, String Senha)
		{
			BllToken bllToken = new BllToken();
			return bllToken.Login(Email, Senha);
		}
	}
}
