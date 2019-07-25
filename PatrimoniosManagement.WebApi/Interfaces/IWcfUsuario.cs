using PatrimoniosManagement.Bll.Utils;
using PatrimoniosManagement.Entity;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PatrimoniosManagement.WebApi.Interfaces
{
	[ServiceContract(SessionMode = SessionMode.Allowed)]
	public interface IWcfUsuario
	{
		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Lista/{token}")]
		WcfResult<List<Usuario>> ListaUsuarios(String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Insere")]
		WcfResult<Int32> InsereUsuario(String Nome, String Email, String Senha, String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Remove")]
		WcfResult<Boolean> RemoveUsuario(Int32 UsuarioId, String token);
	}
}
