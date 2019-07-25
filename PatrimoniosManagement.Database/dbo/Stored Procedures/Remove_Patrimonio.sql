
-- =============================================
-- Author: Jonatã Cioni
-- Create date: 23/07/2019
-- Description:	Remove um patrimonio
-- =============================================
CREATE PROCEDURE Remove_Patrimonio
(
	@PatrimonioId AS INT
)
AS
BEGIN
	UPDATE patrimonio SET
		patrimonio_dataremocao = GETDATE(),
		patrimonio_ativo = 0,
		patrimonio_deletado = 1
	WHERE patrimonio_id = @PatrimonioId
END
