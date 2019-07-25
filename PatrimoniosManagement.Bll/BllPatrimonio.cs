using PatrimoniosManagement.Bll.Utils;
using PatrimoniosManagement.Bll.Utils.Enums;
using PatrimoniosManagement.Dal;
using PatrimoniosManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatrimoniosManagement.Bll
{
	public class BllPatrimonio
	{
		private DalPatrimonio dalPatrimonio;
		private DalMarca dalMarca;
		private DalUsuario dalUsuario;
		private BllToken bllToken;
		private String token;

		public BllPatrimonio(String token)
		{
			this.dalPatrimonio = new DalPatrimonio();
			this.bllToken = new BllToken();
			this.token = token;
		}

		public WcfResult<List<Patrimonio>> ListaPatrimonios(Int32? PatrimonioId, Int32? UsuarioId, Boolean? IsAtivo)
		{
			WcfResult<List<Patrimonio>> ret = new WcfResult<List<Patrimonio>>(this.token);
			try
			{
				if (ret.TokenResult.MessageType == MessageType.Ok)
				{
					ret.DataResult = this.dalPatrimonio.ListaPatrimonios(PatrimonioId, UsuarioId, IsAtivo);
				}
			}
			catch (Exception ex)
			{
				ret.ErrorMessage = ex.Message;
			}
			return ret;
		}

		public WcfResult<Int32> InserePatrimonio(Int32 UsuarioId, Int32 MarcaId, String Nome, String Descricao)
		{
			WcfResult<Int32> ret = new WcfResult<Int32>(this.token);
			try
			{
				this.Validacoes(0, UsuarioId, MarcaId, Nome);
				if (ret.TokenResult.MessageType == MessageType.Ok)
				{
					ret.DataResult = this.dalPatrimonio.InserePatrimonio(UsuarioId, MarcaId, Nome, Descricao);
				}
			}
			catch (Exception ex)
			{
				ret.ErrorMessage = ex.Message;
			}
			return ret;
		}

		public WcfResult<Boolean> AtualizaPatrimonio(Int32 PatrimonioId, Int32 UsuarioId, Int32 MarcaId, String Nome, String Descricao, Boolean Ativo)
		{
			WcfResult<Boolean> ret = new WcfResult<Boolean>(this.token);
			try
			{
				this.Validacoes(PatrimonioId, UsuarioId, MarcaId, Nome);
				if (this.dalPatrimonio.ListaPatrimonios(PatrimonioId, null, null).Count <= 0 && this.dalPatrimonio.ListaPatrimonios(PatrimonioId, null, false).Count <= 0)
				{
					throw new Exception(Utils.Utils.GetDescriptionEnum(MessageType.PatrimonioInexistente));
				}
				if (ret.TokenResult.MessageType == MessageType.Ok)
				{
					this.dalPatrimonio.AtualizaPatrimonio(PatrimonioId, UsuarioId, MarcaId, Nome, Descricao, Ativo);
					ret.DataResult = true;
				}
			}
			catch (Exception ex)
			{
				ret.ErrorMessage = ex.Message;
			}
			return ret;
		}

		public WcfResult<Boolean> RemovePatrimonio(Int32 PatrimonioId)
		{
			WcfResult<Boolean> ret = new WcfResult<Boolean>(this.token);
			try
			{
				if (ret.TokenResult.MessageType == MessageType.Ok)
				{
					this.dalPatrimonio.RemovePatrimonio(PatrimonioId);
					ret.DataResult = true;
				}
			}
			catch (Exception ex)
			{
				ret.ErrorMessage = ex.Message;
			}
			return ret;
		}

		private void Validacoes(Int32 PatrimonioId, Int32 UsuarioId, Int32 MarcaId, String Nome)
		{
			this.dalMarca = new DalMarca();
			this.dalUsuario = new DalUsuario();
			if (!this.dalUsuario.ListaUsuarios().Any(u => u.Id == UsuarioId))
			{
				throw new Exception(Utils.Utils.GetDescriptionEnum(MessageType.UsuarioInexistente));
			}
			if (this.dalMarca.ListaMarcas(MarcaId, null, null).Count <= 0)
			{
				throw new Exception(Utils.Utils.GetDescriptionEnum(MessageType.MarcaInexistente));
			}
			if (PatrimonioId > 0 && this.dalPatrimonio.ListaPatrimonios(null, null, null).Any(p => p.Nome == Nome && p.Id != PatrimonioId))
			{
				throw new Exception(Utils.Utils.GetDescriptionEnum(MessageType.NomePatrimonioRepetido));
			}
			if (PatrimonioId > 0 && this.dalPatrimonio.ListaPatrimonios(null, null, false).Any(p => p.Nome == Nome && p.Id != PatrimonioId))
			{
				throw new Exception(Utils.Utils.GetDescriptionEnum(MessageType.NomePatrimonioRepetido));
			}
		}
	}
}
