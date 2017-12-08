CREATE TABLE [dbo].[Servidores_Configuraciones_MotorBaseDeDatos] (
    [Id]                 INT          IDENTITY (1, 1) NOT NULL,
    [MotorBaseDeDatosId] INT          NOT NULL,
    [Usuario]            VARCHAR (50) NOT NULL,
    [Clave]              VARCHAR (50) NOT NULL,
    [Direccion]          VARCHAR (50) NOT NULL,
    [Puerto]             VARCHAR (6)  NULL,
    [UsuarioAgregaId]    INT          NOT NULL,
    [Activo]             INT          CONSTRAINT [DF_Servidores_Configuraciones_MotorBaseDeDatos_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Servidores_Configuraciones_MotorBaseDeDatos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Servidores_Configuraciones_MotorBaseDeDatos_Servidores_MotoresBasesDeDatos] FOREIGN KEY ([MotorBaseDeDatosId]) REFERENCES [dbo].[Servidores_MotoresBasesDeDatos] ([Id]),
    CONSTRAINT [FK_Servidores_Configuraciones_MotorBaseDeDatos_Usuarios] FOREIGN KEY ([UsuarioAgregaId]) REFERENCES [dbo].[Usuarios] ([Id])
);

