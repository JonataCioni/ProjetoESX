using PatrimoniosManagement.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace PatrimoniosManagement.Dal
{
	public class DalUsuario
	{
		SqlConnection sqlConn;

		public DalUsuario()
		{
			this.sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
			this.sqlConn.Open();
		}

		public Boolean Login(String Email, String Senha)
		{
			DbCommand command = new SqlCommand("dbo.Lista_Usuarios", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@Email", Email));
			command.Parameters.Add(new SqlParameter("@Senha", Senha));

			DbDataReader reader = command.ExecuteReader();
			if(reader.Read())
			{
				return true;
			}
			reader.Close();
			return false;
		}

		public List<Usuario> ListaUsuarios()
		{
			DbCommand command = new SqlCommand("dbo.Lista_Usuarios", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			DbDataReader reader = command.ExecuteReader();
			List<Usuario> lista = new List<Usuario>();
			while(reader.Read())
			{
				Usuario usuario = new Usuario();
				usuario.Id = reader.GetInt32(0);
				usuario.Nome = reader.GetString(1);
				usuario.Email = reader.GetString(2);
				usuario.Senha = reader.GetString(3);
				usuario.DataCadastro = reader.GetDateTime(4);
				if(!reader.IsDBNull(5))
				{
					usuario.DataAlteracao = reader.GetDateTime(5);
				}
				lista.Add(usuario);
			}
			reader.Close();
			return lista;
		}

		public Int32 InsereUsuario(String Nome, String Email, String Senha)
		{
			DbCommand command = new SqlCommand("dbo.Insere_Usuario", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@Nome", Nome));
			command.Parameters.Add(new SqlParameter("@Email", Email));
			command.Parameters.Add(new SqlParameter("@Senha", Senha));

			return Convert.ToInt32(command.ExecuteScalar());
		}

		public void RemoveUsuario(Int32 UsuarioId)
		{
			DbCommand command = new SqlCommand("dbo.Remove_Usuario", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@UsuarioId", UsuarioId));

			command.ExecuteNonQuery();
		}

		~DalUsuario()
		{
			this.sqlConn.Close();
		}
	}
}
