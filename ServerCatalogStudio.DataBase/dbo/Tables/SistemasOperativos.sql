CREATE TABLE [dbo].[SistemasOperativos] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion]     VARCHAR (50) NOT NULL,
    [UsuarioAgregaId] INT          NOT NULL,
    [Activo]          INT          CONSTRAINT [DF_SistemasOperativos_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_SistemasOperativos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SistemasOperativos_Usuarios] FOREIGN KEY ([UsuarioAgregaId]) REFERENCES [dbo].[Usuarios] ([Id])
);

