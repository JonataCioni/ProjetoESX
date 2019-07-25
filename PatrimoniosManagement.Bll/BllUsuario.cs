using PatrimoniosManagement.Bll.Utils;
using PatrimoniosManagement.Bll.Utils.Enums;
using PatrimoniosManagement.Dal;
using PatrimoniosManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatrimoniosManagement.Bll
{
	public class BllUsuario
	{
		private DalUsuario dalUsuario;
		private BllToken bllToken;
		private String token;

		public BllUsuario(String token)
		{
			this.dalUsuario = new DalUsuario();
			this.bllToken = new BllToken();
			this.token = token;
		}

		public WcfResult<List<Usuario>> ListaUsuarios()
		{
			WcfResult<List<Usuario>> ret = new WcfResult<List<Usuario>>(this.token);
			try
			{
				if(ret.TokenResult.MessageType == MessageType.Ok)
				{
					ret.DataResult = this.dalUsuario.ListaUsuarios();
				}
			}
			catch (Exception ex)
			{
				ret.ErrorMessage = ex.Message;
			}
			return ret;
		}

		public WcfResult<Int32> InsereUsuario(String Nome, String Email, String Senha)
		{
			WcfResult<Int32> ret = new WcfResult<Int32>(this.token);
			try
			{
				if(this.dalUsuario.ListaUsuarios().Any(u => u.Email == Email))
				{
					throw new Exception(Utils.Utils.GetDescriptionEnum(MessageType.EmailUsuarioRepetido));
				}
				if (ret.TokenResult.MessageType == MessageType.Ok)
				{
					ret.DataResult = this.dalUsuario.InsereUsuario(Nome, Email, Senha);
				}
			}
			catch (Exception ex)
			{
				ret.ErrorMessage = ex.Message;
			}
			return ret;
		}

		public WcfResult<Boolean> RemoveUsuario(Int32 UsuarioId)
		{
			WcfResult<Boolean> ret = new WcfResult<Boolean>(this.token);
			try
			{
				if (ret.TokenResult.MessageType == MessageType.Ok)
				{
					this.dalUsuario.RemoveUsuario(UsuarioId);
					ret.DataResult = true;
				}
			}
			catch (Exception ex)
			{
				ret.ErrorMessage = ex.Message;
			}
			return ret;
		}
	}
}
