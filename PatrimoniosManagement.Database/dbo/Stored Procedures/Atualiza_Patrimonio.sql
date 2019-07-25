
-- =============================================
-- Author: Jonatã Cioni
-- Create date: 23/07/2019
-- Description:	Atualiza um patrimonio
-- =============================================
CREATE PROCEDURE Atualiza_Patrimonio
(
	@PatrimonioId AS INT,
	@UsuarioId AS INT,
	@MarcaId AS INT,
	@Nome AS VARCHAR(120),
	@Ativo AS BIT = 1,
	@Descricao AS VARCHAR(MAX) = NULL
)
AS
BEGIN
	UPDATE patrimonio SET
		usuario_id = @UsuarioId,
		marca_id = @MarcaId,
		patrimonio_nome = @Nome,
		patrimonio_descricao = @Descricao,
		patrimonio_dataalteracao = GETDATE(),
		patrimonio_ativo = @Ativo
	WHERE patrimonio_id = @PatrimonioId
END