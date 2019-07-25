-- =============================================
-- Author: Jonatã Cioni
-- Create date: 23/07/2019
-- Description:	Realiza login ou lista todos os usuarios não deletados
-- =============================================
CREATE PROCEDURE Lista_Usuarios
(
	@Email AS VARCHAR(120) = NULL,
	@Senha AS VARCHAR(20) = NULL
)
AS
BEGIN
	IF(@Email IS NULL AND @Senha IS NULL)
	BEGIN
		SELECT 
			u.usuario_id, 
			u.usuario_nome, 
			u.usuario_email, 
			u.usuario_senha,
			u.usuario_datacadastro,
			u.usuario_dataalteracao
		FROM usuario AS u
		WHERE u.usuario_deletado = 0
	END
	ELSE
	BEGIN
		SELECT 
			u.usuario_id, 
			u.usuario_nome, 
			u.usuario_email, 
			u.usuario_senha,
			u.usuario_datacadastro,
			u.usuario_dataalteracao
		FROM usuario AS u
		WHERE u.usuario_ativo = 1
		AND u.usuario_deletado = 0
		AND u.usuario_email = @Email
		AND u.usuario_senha = @Senha
	END
END
