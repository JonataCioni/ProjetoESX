CREATE TABLE [dbo].[marca] (
    [marca_id]            INT           IDENTITY (1, 1) NOT NULL,
    [usuario_id]          INT           NOT NULL,
    [marca_nome]          VARCHAR (120) NOT NULL,
    [marca_datacadastro]  DATETIME      NOT NULL,
    [marca_dataalteracao] DATETIME      NULL,
    [marca_dataremocao]   DATETIME      NULL,
    [marca_ativo]         BIT           CONSTRAINT [DF_marca_marca_ativo] DEFAULT ((1)) NOT NULL,
    [marca_deletado]      BIT           CONSTRAINT [DF_marca_marca_deletado] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_marca] PRIMARY KEY CLUSTERED ([marca_id] ASC),
    CONSTRAINT [FK_marca_usuario] FOREIGN KEY ([usuario_id]) REFERENCES [dbo].[usuario] ([usuario_id])
);

