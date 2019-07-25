
-- =============================================
-- Author: Jonatã Cioni
-- Create date: 23/07/2019
-- Description:	Lista uma ou todas as marcas ativas e não deletadas
-- =============================================
CREATE PROCEDURE Lista_Marcas
(
	@MarcaId AS INT = NULL,
	@UsuarioId AS INT = NULL,
	@IsAtivo AS BIT = 1
)
AS
BEGIN
	SELECT 
		m.marca_id, 
		m.usuario_id, 
		m.marca_nome, 
		m.marca_datacadastro,
		m.marca_dataalteracao
	FROM marca AS m
	WHERE m.marca_deletado = 0
	AND  m.marca_ativo = @IsAtivo
	AND m.marca_id = ISNULL(@MarcaId, m.marca_id)
	AND m.usuario_id = ISNULL(@UsuarioId, m.usuario_id)
END
