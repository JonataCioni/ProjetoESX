using System.ComponentModel;

namespace PatrimoniosManagement.Bll.Utils.Enums
{
	public enum MessageType
	{
		[Description("Acesso garantido")]
		Ok = 0,
		[Description("Tempo Expirado")]
		TimeExpired = 1,
		[Description("Sem Permissão de acesso")]
		NotPermition = 2,

		[Description("Não é permitido cadastro de email repetido")]
		EmailUsuarioRepetido = 3,
		[Description("Não é permitido cadastro de Marca com nome repetido")]
		NomeMarcaRepetido = 4,
		[Description("Não é permitido cadastro de Patrimonio com nome repetido")]
		NomePatrimonioRepetido = 5,
		[Description("Marca informada não existe ou foi deletada")]
		MarcaInexistente = 6,
		[Description("Patrimonio informado não existe ou foi deletado")]
		PatrimonioInexistente = 7,
		[Description("Usuário informado não existe ou foi deletado")]
		UsuarioInexistente = 8
	}
}
