using PatrimoniosManagement.Bll.Utils;
using PatrimoniosManagement.Entity;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PatrimoniosManagement.WebApi.Interfaces
{
	[ServiceContract(SessionMode = SessionMode.Allowed)]
	public interface IWcfPatrimonio
	{
		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Get/{PatrimonioId}/{token}")]
		WcfResult<List<Patrimonio>> GetPatrimonio(String PatrimonioId, String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Lista/{token}")]
		WcfResult<List<Patrimonio>> ListaPatrimonios(String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "ListaPorUsuario/{UsuarioId}/{token}")]
		WcfResult<List<Patrimonio>> ListaPatrimoniosPorUsuario(String UsuarioId, String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "ListaInativos/{token}")]
		WcfResult<List<Patrimonio>> ListaPatrimoniosInativos(String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Insere")]
		WcfResult<Int32> InserePatrimonio(Int32 UsuarioId, Int32 MarcaId, String Nome, String Descricao, String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Atualiza")]
		WcfResult<Boolean> AtualizaPatrimonio(Int32 PatrimonioId, Int32 UsuarioId, Int32 MarcaId, String Nome, String Descricao, Boolean Ativo, String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Remove")]
		WcfResult<Boolean> RemovePatrimonio(Int32 PatrimonioId, String token);
	}
}
