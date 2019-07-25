using PatrimoniosManagement.Bll.Utils;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PatrimoniosManagement.WebApi.Interfaces
{
	[ServiceContract(SessionMode = SessionMode.Allowed)]
	public interface IWcfToken
	{
		[OperationContract(Action = "Token", IsInitiating = true)]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
		TokenResult Token(String Email, String Senha);
	}
}
