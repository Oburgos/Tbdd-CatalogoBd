CREATE TABLE [dbo].[Servidores_MotoresBasesDeDatos] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion]     VARCHAR (50) NOT NULL,
    [UsuarioAgregaId] INT          NOT NULL,
    [Activo]          INT          CONSTRAINT [DF_Servidores_MotoresBasesDeDatos_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Servidores_MotoresBasesDeDatos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Servidores_MotoresBasesDeDatos_Usuarios] FOREIGN KEY ([UsuarioAgregaId]) REFERENCES [dbo].[Usuarios] ([Id])
);

