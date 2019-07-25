using PatrimoniosManagement.Bll;
using PatrimoniosManagement.Bll.Utils;
using PatrimoniosManagement.Entity;
using PatrimoniosManagement.WebApi.Interfaces;
using System;
using System.Collections.Generic;

namespace PatrimoniosManagement.WebApi
{
	public class WcfUsuario : IWcfUsuario
	{
		public WcfResult<List<Usuario>> ListaUsuarios(String token)
		{
			BllUsuario bllUsuario = new BllUsuario(token);
			return bllUsuario.ListaUsuarios();
		}

		public WcfResult<Int32> InsereUsuario(String Nome, String Email, String Senha, String token)
		{
			BllUsuario bllUsuario = new BllUsuario(token);
			return bllUsuario.InsereUsuario(Nome, Email, Senha);
		}

		public WcfResult<bool> RemoveUsuario(Int32 UsuarioId, String token)
		{
			BllUsuario bllUsuario = new BllUsuario(token);
			return bllUsuario.RemoveUsuario(UsuarioId);
		}
	}
}
