CREATE TABLE [dbo].[usuario] (
    [usuario_id]            INT           IDENTITY (1, 1) NOT NULL,
    [usuario_nome]          VARCHAR (120) NOT NULL,
    [usuario_email]         VARCHAR (120) NOT NULL,
    [usuario_senha]         VARCHAR (120) NOT NULL,
    [usuario_datacadastro]  DATETIME      NOT NULL,
    [usuario_dataalteracao] DATETIME      NULL,
    [usuario_dataremocao]   DATETIME      NULL,
    [usuario_ativo]         BIT           CONSTRAINT [DF_usuario_usuario_ativo] DEFAULT ((1)) NOT NULL,
    [usuario_deletado]      BIT           CONSTRAINT [DF_usuario_usuario_deletado] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED ([usuario_id] ASC)
);

