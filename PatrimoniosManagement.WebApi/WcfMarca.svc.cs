using PatrimoniosManagement.Bll;
using PatrimoniosManagement.Bll.Utils;
using PatrimoniosManagement.Entity;
using PatrimoniosManagement.WebApi.Interfaces;
using System;
using System.Collections.Generic;

namespace PatrimoniosManagement.WebApi
{
	public class WcfMarca : IWcfMarca
	{
		public WcfResult<List<Marca>> GetMarca(String MarcaId, String token)
		{
			BllMarca bllMarca = new BllMarca(token);
			Int32 idMarca = Int32.Parse(MarcaId);
			return bllMarca.ListaMarcas(idMarca, null, null);
		}

		public WcfResult<List<Marca>> ListaMarcas(String token)
		{
			BllMarca bllMarca = new BllMarca(token);
			return bllMarca.ListaMarcas(null, null, null);
		}

		public WcfResult<List<Marca>> ListaMarcasPorUsuario(String UsuarioId, String token)
		{
			BllMarca bllMarca = new BllMarca(token);
			Int32 idUsuario = Int32.Parse(UsuarioId);
			return bllMarca.ListaMarcas(null, idUsuario, null);
		}

		public WcfResult<List<Marca>> ListaMarcasInativos(String token)
		{
			BllMarca bllMarca = new BllMarca(token);
			return bllMarca.ListaMarcas(null, null, false);
		}

		public WcfResult<List<Patrimonio>> ListaPatrimoniosMarca(String MarcaId, String token)
		{
			BllMarca bllMarca = new BllMarca(token);
			Int32 idMarca = Int32.Parse(MarcaId);
			return bllMarca.ListaPatrimoniosMarca(idMarca);
		}

		public WcfResult<Int32> InsereMarca(Int32 UsuarioId, String Nome, String token)
		{
			BllMarca bllMarca = new BllMarca(token);
			return bllMarca.InsereMarca(UsuarioId, Nome);
		}

		public WcfResult<bool> AtualizaMarca(Int32 MarcaId, Int32 UsuarioId, String Nome, Boolean Ativo, String token)
		{
			BllMarca bllMarca = new BllMarca(token);
			return bllMarca.AtualizaMarca(MarcaId, UsuarioId, Nome, Ativo);
		}

		public WcfResult<bool> RemoveMarca(Int32 MarcaId, String token)
		{
			BllMarca bllMarca = new BllMarca(token);
			return bllMarca.RemoveMarca(MarcaId);
		}
	}
}
