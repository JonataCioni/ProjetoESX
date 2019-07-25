using PatrimoniosManagement.Bll.Utils;
using PatrimoniosManagement.Bll.Utils.Enums;
using PatrimoniosManagement.Dal;
using PatrimoniosManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatrimoniosManagement.Bll
{
	public class BllMarca
	{
		private DalMarca dalMarca;
		private DalUsuario dalUsuario;
		private BllToken bllToken;
		private String token;

		public BllMarca(String token)
		{
			this.dalMarca = new DalMarca();
			this.bllToken = new BllToken();
			this.token = token;
		}

		public WcfResult<List<Marca>> ListaMarcas(Int32? MarcaId, Int32? UsuarioId, Boolean? IsAtivo)
		{
			WcfResult<List<Marca>> ret = new WcfResult<List<Marca>>(this.token);
			try
			{
				if (ret.TokenResult.MessageType == MessageType.Ok)
				{
					ret.DataResult = this.dalMarca.ListaMarcas(MarcaId, UsuarioId, IsAtivo);
				}
			}
			catch (Exception ex)
			{
				ret.ErrorMessage = ex.Message;
			}
			return ret;
		}

		public WcfResult<List<Patrimonio>> ListaPatrimoniosMarca(Int32 MarcaId)
		{
			WcfResult<List<Patrimonio>> ret = new WcfResult<List<Patrimonio>>(this.token);
			try
			{
				if (ret.TokenResult.MessageType == MessageType.Ok)
				{
					ret.DataResult = this.dalMarca.ListaPatrimoniosMarca(MarcaId);
				}
			}
			catch (Exception ex)
			{
				ret.ErrorMessage = ex.Message;
			}
			return ret;
		}

		public WcfResult<Int32> InsereMarca(Int32 UsuarioId, String Nome)
		{
			WcfResult<Int32> ret = new WcfResult<Int32>(this.token);
			try
			{
				this.Validacoes(0, UsuarioId, Nome);
				if (ret.TokenResult.MessageType == MessageType.Ok)
				{
					ret.DataResult = this.dalMarca.InsereMarca(UsuarioId, Nome);
				}
			}
			catch (Exception ex)
			{
				ret.ErrorMessage = ex.Message;
			}
			return ret;
		}

		public WcfResult<Boolean> AtualizaMarca(Int32 MarcaId, Int32 UsuarioId, String Nome, Boolean Ativo)
		{
			WcfResult<Boolean> ret = new WcfResult<Boolean>(this.token);
			try
			{
				this.Validacoes(MarcaId, UsuarioId, Nome);
				if (this.dalMarca.ListaMarcas(MarcaId, null, null).Count <= 0 && this.dalMarca.ListaMarcas(MarcaId, null, false).Count <= 0)
				{
					throw new Exception(Utils.Utils.GetDescriptionEnum(MessageType.MarcaInexistente));
				}
				if (ret.TokenResult.MessageType == MessageType.Ok)
				{
					this.dalMarca.AtualizaMarca(MarcaId, UsuarioId, Nome, Ativo);
					ret.DataResult = true;
				}
			}
			catch (Exception ex)
			{
				ret.ErrorMessage = ex.Message;
			}
			return ret;
		}

		public WcfResult<Boolean> RemoveMarca(Int32 MarcaId)
		{
			WcfResult<Boolean> ret = new WcfResult<Boolean>(this.token);
			try
			{
				if (ret.TokenResult.MessageType == MessageType.Ok)
				{
					this.dalMarca.RemoveMarca(MarcaId);
					ret.DataResult = true;
				}
			}
			catch (Exception ex)
			{
				ret.ErrorMessage = ex.Message;
			}
			return ret;
		}

		private void Validacoes(Int32 MarcaId, Int32 UsuarioId, String Nome)
		{
			this.dalUsuario = new DalUsuario();
			if (!this.dalUsuario.ListaUsuarios().Any(u => u.Id == UsuarioId))
			{
				throw new Exception(Utils.Utils.GetDescriptionEnum(MessageType.UsuarioInexistente));
			}
			if (MarcaId > 0 && this.dalMarca.ListaMarcas(null, null, null).Any(m => m.Nome == Nome && m.Id != MarcaId))
			{
				throw new Exception(Utils.Utils.GetDescriptionEnum(MessageType.NomeMarcaRepetido));
			}
			if (MarcaId > 0 && this.dalMarca.ListaMarcas(null, null, false).Any(m => m.Nome == Nome && m.Id != MarcaId))
			{
				throw new Exception(Utils.Utils.GetDescriptionEnum(MessageType.NomeMarcaRepetido));
			}
		}
	}
}
