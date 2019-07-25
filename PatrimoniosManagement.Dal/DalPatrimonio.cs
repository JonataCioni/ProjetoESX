using PatrimoniosManagement.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace PatrimoniosManagement.Dal
{
	public class DalPatrimonio
	{
		SqlConnection sqlConn;

		public DalPatrimonio()
		{
			this.sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
			this.sqlConn.Open();
		}

		public List<Patrimonio> ListaPatrimonios(Int32? PatrimonioId, Int32? UsuarioId, Boolean? IsAtivo)
		{
			DbCommand command = new SqlCommand("dbo.Lista_Patrimonios", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			if(PatrimonioId.HasValue)
			{
				command.Parameters.Add(new SqlParameter("@PatrimonioId", PatrimonioId.Value));
			}
			if(UsuarioId.HasValue)
			{
				command.Parameters.Add(new SqlParameter("@UsuarioId", UsuarioId.Value));
			}
			if(IsAtivo.HasValue)
			{
				command.Parameters.Add(new SqlParameter("@IsAtivo", IsAtivo.Value));
			}

			DbDataReader reader = command.ExecuteReader();
			List<Patrimonio> lista = new List<Patrimonio>();
			while (reader.Read())
			{
				Patrimonio patrimonio = new Patrimonio();
				patrimonio.Id = reader.GetInt32(0);
				patrimonio.UsuarioId = reader.GetInt32(1);
				patrimonio.MarcaId = reader.GetInt32(2);
				patrimonio.NumeroTombo = reader.GetInt32(3);
				patrimonio.Nome = reader.GetString(4);
				if(!reader.IsDBNull(5))
				{
					patrimonio.Descricao = reader.GetString(5);
				}
				patrimonio.DataCadastro = reader.GetDateTime(6);
				if (!reader.IsDBNull(7))
				{
					patrimonio.DataAlteracao = reader.GetDateTime(7);
				}
				lista.Add(patrimonio);
			}
			reader.Close();
			return lista;
		}

		public Int32 InserePatrimonio(Int32 UsuarioId, Int32 MarcaId, String Nome, String Descricao)
		{
			DbCommand command = new SqlCommand("dbo.Insere_Patrimonio", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@UsuarioId", UsuarioId));
			command.Parameters.Add(new SqlParameter("@MarcaId", MarcaId));
			command.Parameters.Add(new SqlParameter("@Nome", Nome));
			command.Parameters.Add(new SqlParameter("@Descricao", Descricao));

			return Convert.ToInt32(command.ExecuteScalar());
		}

		public void AtualizaPatrimonio(Int32 PatrimonioId, Int32 UsuarioId, Int32 MarcaId, String Nome, String Descricao, Boolean Ativo)
		{
			DbCommand command = new SqlCommand("dbo.Atualiza_Patrimonio", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@PatrimonioId", PatrimonioId));
			if(UsuarioId > 0)
			{
				command.Parameters.Add(new SqlParameter("@UsuarioId", UsuarioId));
			}
			if(MarcaId > 0)
			{
				command.Parameters.Add(new SqlParameter("@MarcaId", MarcaId));
			}
			if(!String.IsNullOrEmpty(Nome))
			{
				command.Parameters.Add(new SqlParameter("@Nome", Nome));
			}
			if(!String.IsNullOrEmpty(Descricao))
			{
				command.Parameters.Add(new SqlParameter("@Descricao", Descricao));
			}
			command.Parameters.Add(new SqlParameter("@Ativo", Ativo));

			command.ExecuteNonQuery();
		}

		public void RemovePatrimonio(Int32 PatrimonioId)
		{
			DbCommand command = new SqlCommand("dbo.Remove_Patrimonio", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@PatrimonioId", PatrimonioId));

			command.ExecuteNonQuery();
		}

		~DalPatrimonio()
		{
			this.sqlConn.Close();
		}
	}
}
