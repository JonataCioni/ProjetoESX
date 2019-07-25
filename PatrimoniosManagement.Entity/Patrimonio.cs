using System;
using System.Runtime.Serialization;

namespace PatrimoniosManagement.Entity
{
	[DataContract]
	public class Patrimonio
	{
		[DataMember]
		public Int32 Id { get; set; }
		[DataMember]
		public Int32 UsuarioId { get; set; }
		[DataMember]
		public Int32 MarcaId { get; set; }
		[DataMember]
		public Int32 NumeroTombo { get; set; }
		[DataMember]
		public String Nome { get; set; }
		[DataMember]
		public String Descricao { get; set; }
		[DataMember]
		public DateTime DataCadastro { get; set; }
		[DataMember]
		public DateTime? DataAlteracao { get; set; }

		public DateTime? DataRemocao { get; set; }
		public Boolean Ativo { get; set; }
		public Boolean Deletado { get; set; }
	}
}
