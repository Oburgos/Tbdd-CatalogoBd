CREATE TABLE [dbo].[Servidores] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [AmbienteId]         INT           NOT NULL,
    [ServidorTipoId]     INT           NOT NULL,
    [Nombre]             VARCHAR (100) NOT NULL,
    [SistemaOperativoId] INT           NOT NULL,
    [Memoria]            VARCHAR (50)  NOT NULL,
    [Procesador]         VARCHAR (50)  NOT NULL,
    [UsuarioAgregaId]    INT           NOT NULL,
    [Activo]             INT           CONSTRAINT [DF_Servidores_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Servidores] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Servidores_Ambientes] FOREIGN KEY ([AmbienteId]) REFERENCES [dbo].[Ambientes] ([Id]),
    CONSTRAINT [FK_Servidores_Servidores_Tipo] FOREIGN KEY ([ServidorTipoId]) REFERENCES [dbo].[Servidores_Tipos] ([Id]),
    CONSTRAINT [FK_Servidores_SistemasOperativos] FOREIGN KEY ([SistemaOperativoId]) REFERENCES [dbo].[SistemasOperativos] ([Id]),
    CONSTRAINT [FK_Servidores_Usuarios1] FOREIGN KEY ([UsuarioAgregaId]) REFERENCES [dbo].[Usuarios] ([Id])
);

