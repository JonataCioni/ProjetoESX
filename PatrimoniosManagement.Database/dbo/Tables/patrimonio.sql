CREATE TABLE [dbo].[patrimonio] (
    [patrimonio_id]            INT           IDENTITY (1, 1) NOT NULL,
    [usuario_id]               INT           NOT NULL,
    [marca_id]                 INT           NOT NULL,
    [patrimonio_numero_tombo]  INT           NOT NULL,
    [patrimonio_nome]          VARCHAR (120) NOT NULL,
    [patrimonio_descricao]     VARCHAR (MAX) NULL,
    [patrimonio_datacadastro]  DATETIME      NOT NULL,
    [patrimonio_dataalteracao] DATETIME      NULL,
    [patrimonio_dataremocao]   DATETIME      NULL,
    [patrimonio_ativo]         BIT           CONSTRAINT [DF_patrimonio_patrimonio_ativo] DEFAULT ((1)) NOT NULL,
    [patrimonio_deletado]      BIT           CONSTRAINT [DF_patrimonio_patrimonio_deletado] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_patrimonio] PRIMARY KEY CLUSTERED ([patrimonio_id] ASC),
    CONSTRAINT [FK_patrimonio_marca] FOREIGN KEY ([marca_id]) REFERENCES [dbo].[marca] ([marca_id]),
    CONSTRAINT [FK_patrimonio_usuario] FOREIGN KEY ([usuario_id]) REFERENCES [dbo].[usuario] ([usuario_id])
);

