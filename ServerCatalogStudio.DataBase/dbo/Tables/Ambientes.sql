CREATE TABLE [dbo].[Ambientes] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]     VARCHAR (100) NOT NULL,
    [UsuarioAgregaId] INT           NOT NULL,
    CONSTRAINT [PK_Ambiente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

