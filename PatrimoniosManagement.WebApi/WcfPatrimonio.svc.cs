using PatrimoniosManagement.Bll;
using PatrimoniosManagement.Bll.Utils;
using PatrimoniosManagement.Entity;
using PatrimoniosManagement.WebApi.Interfaces;
using System;
using System.Collections.Generic;

namespace PatrimoniosManagement.WebApi
{
	public class WcfPatrimonio : IWcfPatrimonio
	{
		public WcfResult<List<Patrimonio>> GetPatrimonio(String PatrimonioId, String token)
		{
			BllPatrimonio bllPatrimonio = new BllPatrimonio(token);
			Int32 idPatrimonio = Int32.Parse(PatrimonioId);
			return bllPatrimonio.ListaPatrimonios(idPatrimonio, null, null);
		}

		public WcfResult<List<Patrimonio>> ListaPatrimonios(String token)
		{
			BllPatrimonio bllPatrimonio = new BllPatrimonio(token);
			return bllPatrimonio.ListaPatrimonios(null, null, null);
		}

		public WcfResult<List<Patrimonio>> ListaPatrimoniosPorUsuario(String UsuarioId, String token)
		{
			BllPatrimonio bllPatrimonio = new BllPatrimonio(token);
			Int32 idUsuario = Int32.Parse(UsuarioId);
			return bllPatrimonio.ListaPatrimonios(null, idUsuario, null);
		}

		public WcfResult<List<Patrimonio>> ListaPatrimoniosInativos(String token)
		{
			BllPatrimonio bllPatrimonio = new BllPatrimonio(token);
			return bllPatrimonio.ListaPatrimonios(null, null, false);
		}

		public WcfResult<Int32> InserePatrimonio(Int32 UsuarioId, Int32 MarcaId, String Nome, String Descricao, String token)
		{
			BllPatrimonio bllPatrimonio = new BllPatrimonio(token);
			return bllPatrimonio.InserePatrimonio(UsuarioId, MarcaId, Nome, Descricao);
		}

		public WcfResult<bool> AtualizaPatrimonio(Int32 PatrimonioId, Int32 UsuarioId, Int32 MarcaId, String Nome, String Descricao, Boolean Ativo, String token)
		{
			BllPatrimonio bllPatrimonio = new BllPatrimonio(token);
			return bllPatrimonio.AtualizaPatrimonio(PatrimonioId, UsuarioId, MarcaId, Nome, Descricao, Ativo);
		}

		public WcfResult<bool> RemovePatrimonio(Int32 PatrimonioId, String token)
		{
			BllPatrimonio bllPatrimonio = new BllPatrimonio(token);
			return bllPatrimonio.RemovePatrimonio(PatrimonioId);
		}
	}
}
