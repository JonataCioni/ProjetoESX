
-- =============================================
-- Author: Jonatã Cioni
-- Create date: 23/07/2019
-- Description:	Lista um ou todos os patrimonios não deletados
-- =============================================
CREATE PROCEDURE Lista_Patrimonios
(
	@PatrimonioId AS INT = NULL,
	@UsuarioId AS INT = NULL,
	@IsAtivo AS BIT = 1
)
AS
BEGIN
	SELECT 
		p.patrimonio_id, 
		p.usuario_id, 
		p.marca_id, 
		p.patrimonio_numero_tombo,
		p.patrimonio_nome, 
		p.patrimonio_descricao, 
		p.patrimonio_datacadastro,
		p.patrimonio_dataalteracao
	FROM patrimonio AS p
	WHERE p.patrimonio_deletado = 0
	AND p.patrimonio_ativo = @IsAtivo
	AND p.patrimonio_id = ISNULL(@PatrimonioId, p.patrimonio_id)
	AND p.usuario_id = ISNULL(@UsuarioId, p.usuario_id)
END
