
-- =============================================
-- Author: Jonatã Cioni
-- Create date: 23/07/2019
-- Description:	Insere um patrimonio
-- =============================================
CREATE PROCEDURE Insere_Patrimonio
(
	@UsuarioId AS INT,
	@MarcaId AS INT,
	@Nome AS VARCHAR(120),
	@Descricao AS VARCHAR(MAX) = NULL
)
AS
BEGIN
	INSERT INTO patrimonio
	(
		usuario_id,
		marca_id,
		patrimonio_numero_tombo,
		patrimonio_nome,
		patrimonio_descricao,
		patrimonio_datacadastro,
		patrimonio_dataalteracao,
		patrimonio_dataremocao,
		patrimonio_ativo,
		patrimonio_deletado
	)
	VALUES
	(
		@UsuarioId,
		@MarcaId,
		(SELECT ISNULL(MAX(p.patrimonio_numero_tombo),0)+1 FROM patrimonio p),
		@Nome,
		@Descricao,
		GETDATE(),
		NULL,
		NULL,
		1,
		0
	)
	SELECT SCOPE_IDENTITY()
END
