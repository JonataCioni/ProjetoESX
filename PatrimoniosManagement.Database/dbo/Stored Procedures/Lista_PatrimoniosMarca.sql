
-- =============================================
-- Author: Jonatã Cioni
-- Create date: 23/07/2019
-- Description:	Lista todos os patrimonios de uma marca
-- =============================================
CREATE PROCEDURE Lista_PatrimoniosMarca
(
	@MarcaId AS INT
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
	INNER JOIN marca AS m
		ON p.marca_id = m.marca_id
	WHERE m.marca_ativo = 1
	AND m.marca_deletado = 0
	AND p.patrimonio_ativo = 1
	AND p.patrimonio_deletado = 0
	AND m.marca_id = @MarcaId
END
