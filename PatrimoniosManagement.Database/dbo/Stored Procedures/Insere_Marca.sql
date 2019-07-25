
-- =============================================
-- Author: Jonatã Cioni
-- Create date: 23/07/2019
-- Description:	Insere uma marca
-- =============================================
CREATE PROCEDURE Insere_Marca
(
	@UsuarioId AS INT,
	@Nome AS VARCHAR(120)
)
AS
BEGIN
	INSERT INTO marca
	(
		usuario_id,
		marca_nome,
		marca_datacadastro,
		marca_dataalteracao,
		marca_dataremocao,
		marca_ativo,
		marca_deletado
	)
	VALUES
	(
		@UsuarioId,
		@Nome,
		GETDATE(),
		NULL,
		NULL,
		1,
		0
	)
	SELECT SCOPE_IDENTITY()
END
