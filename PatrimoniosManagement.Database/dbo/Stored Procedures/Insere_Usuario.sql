
-- =============================================
-- Author: Jonatã Cioni
-- Create date: 23/07/2019
-- Description:	Insere um usuario
-- =============================================
CREATE PROCEDURE Insere_Usuario
(
	@Nome AS VARCHAR(120),
	@Email AS VARCHAR(120),
	@Senha AS VARCHAR(120)
)
AS
BEGIN
	INSERT INTO usuario
	(
		usuario_nome,
		usuario_email,
		usuario_senha,
		usuario_datacadastro,
		usuario_dataalteracao,
		usuario_dataremocao,
		usuario_ativo,
		usuario_deletado
	)
	VALUES
	(
		@Nome,
		@Email,
		@Senha,
		GETDATE(),
		NULL,
		NULL,
		1,
		0
	)

	SELECT SCOPE_IDENTITY()
END
