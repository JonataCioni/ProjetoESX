using PatrimoniosManagement.Bll.Utils;
using PatrimoniosManagement.Entity;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PatrimoniosManagement.WebApi.Interfaces
{
	[ServiceContract(SessionMode = SessionMode.Allowed)]
	public interface IWcfMarca
	{
		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Get/{MarcaId}/{token}")]
		WcfResult<List<Marca>> GetMarca(String MarcaId, String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Lista/{token}")]
		WcfResult<List<Marca>> ListaMarcas(String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "ListaPorUsuario/{UsuarioId}/{token}")]
		WcfResult<List<Marca>> ListaMarcasPorUsuario(String UsuarioId, String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "ListaPatrimonios/{MarcaId}/patrimonios/{token}")]
		WcfResult<List<Patrimonio>> ListaPatrimoniosMarca(String MarcaId, String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "ListaInativos/{token}")]
		WcfResult<List<Marca>> ListaMarcasInativos(String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Insere")]
		WcfResult<Int32> InsereMarca(Int32 UsuarioId, String Nome, String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Atualiza")]
		WcfResult<Boolean> AtualizaMarca(Int32 MarcaId, Int32 UsuarioId, String Nome, Boolean Ativo, String token);

		[OperationContract(IsInitiating = true)]
		[WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "Remove")]
		WcfResult<Boolean> RemoveMarca(Int32 MarcaId, String token);
	}
}
