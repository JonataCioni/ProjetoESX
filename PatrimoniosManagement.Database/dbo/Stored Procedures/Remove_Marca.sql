
-- =============================================
-- Author: Jonatã Cioni
-- Create date: 23/07/2019
-- Description:	Remove uma marca
-- =============================================
CREATE PROCEDURE Remove_Marca
(
	@MarcaId AS INT
)
AS
BEGIN
	UPDATE marca SET
		marca_dataremocao = GETDATE(),
		marca_ativo = 0,
		marca_deletado = 1
	WHERE marca_id = @MarcaId
END
