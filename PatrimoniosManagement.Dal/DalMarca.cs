using PatrimoniosManagement.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace PatrimoniosManagement.Dal
{
	public class DalMarca
	{
		SqlConnection sqlConn;

		public DalMarca()
		{
			this.sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
			this.sqlConn.Open();
		}

		public List<Marca> ListaMarcas(Int32? MarcaId, Int32? UsuarioId, Boolean? IsAtivo)
		{
			DbCommand command = new SqlCommand("dbo.Lista_Marcas", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			if (MarcaId.HasValue)
			{
				command.Parameters.Add(new SqlParameter("@MarcaId", MarcaId.Value));
			}
			if (UsuarioId.HasValue)
			{
				command.Parameters.Add(new SqlParameter("@UsuarioId", UsuarioId.Value));
			}
			if (IsAtivo.HasValue)
			{
				command.Parameters.Add(new SqlParameter("@IsAtivo", IsAtivo.Value));
			}

			DbDataReader reader = command.ExecuteReader();
			List<Marca> lista = new List<Marca>();
			while (reader.Read())
			{
				Marca marca = new Marca();
				marca.Id = reader.GetInt32(0);
				marca.UsuarioId = reader.GetInt32(1);
				marca.Nome = reader.GetString(2);
				marca.DataCadastro = reader.GetDateTime(3);
				if(!reader.IsDBNull(4))
				{
					marca.DataAlteracao = reader.GetDateTime(4);
				}
				lista.Add(marca);
			}
			reader.Close();
			return lista;
		}

		public List<Patrimonio> ListaPatrimoniosMarca(Int32 MarcaId)
		{
			DbCommand command = new SqlCommand("dbo.Lista_PatrimoniosMarca", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@MarcaId", MarcaId));

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
				if (!reader.IsDBNull(5))
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

		public Int32 InsereMarca(Int32 UsuarioId, String Nome)
		{
			DbCommand command = new SqlCommand("dbo.Insere_Marca", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@UsuarioId", UsuarioId));
			command.Parameters.Add(new SqlParameter("@Nome", Nome));

			return Convert.ToInt32(command.ExecuteScalar());
		}

		public void AtualizaMarca(Int32 MarcaId, Int32 UsuarioId, String Nome, Boolean Ativo)
		{
			DbCommand command = new SqlCommand("dbo.Atualiza_Marca", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@MarcaId", MarcaId));
			if(UsuarioId > 0)
			{
				command.Parameters.Add(new SqlParameter("@UsuarioId", UsuarioId));
			}
			if(!String.IsNullOrEmpty(Nome))
			{
				command.Parameters.Add(new SqlParameter("@Nome", Nome));
			}
			command.Parameters.Add(new SqlParameter("@Ativo", Ativo));

			command.ExecuteNonQuery();
		}

		public void RemoveMarca(Int32 MarcaId)
		{
			DbCommand command = new SqlCommand("dbo.Remove_Marca", this.sqlConn);
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@MarcaId", MarcaId));

			command.ExecuteNonQuery();
		}

		~DalMarca()
		{
			this.sqlConn.Close();
		}
	}
}
