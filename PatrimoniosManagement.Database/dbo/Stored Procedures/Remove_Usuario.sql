
-- =============================================
-- Author: Jonatã Cioni
-- Create date: 23/07/2019
-- Description:	Deleta um usuário
-- =============================================
CREATE PROCEDURE Remove_Usuario
(
	@UsuarioId AS INT
)
AS
BEGIN
	UPDATE usuario SET
		usuario_dataremocao = GETDATE(),
		usuario_ativo = 0,
		usuario_deletado = 1
	WHERE usuario_id = @UsuarioId
END
