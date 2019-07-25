
-- =============================================
-- Author: Jonatã Cioni
-- Create date: 23/07/2019
-- Description:	Atualiza uma marca
-- =============================================
CREATE PROCEDURE Atualiza_Marca
(
	@MarcaId AS INT,
	@UsuarioId AS INT,
	@Nome AS VARCHAR(120),
	@Ativo AS BIT = 1
)
AS
BEGIN
	UPDATE marca SET
		usuario_id = @UsuarioId,
		marca_nome = @Nome,
		marca_dataalteracao = GETDATE(),
		marca_ativo = @Ativo
	WHERE marca_id = @MarcaId
END
