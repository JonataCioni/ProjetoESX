using System;
using System.Runtime.Serialization;

namespace PatrimoniosManagement.Entity
{
	[DataContract]
	public class Usuario
	{
		[DataMember]
		public Int32 Id { get; set; }
		[DataMember]
		public String Nome { get; set; }
		[DataMember]
		public String Email { get; set; }
		[DataMember]
		public String Senha { get; set; }
		[DataMember]
		public DateTime DataCadastro { get; set; }
		[DataMember]
		public DateTime? DataAlteracao { get; set; }

		public DateTime? DataRemocao { get; set; }
		public Boolean Ativo { get; set; }
		public Boolean Deletado { get; set; }
	}
}
