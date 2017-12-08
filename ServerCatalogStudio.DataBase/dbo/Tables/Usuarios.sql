CREATE TABLE [dbo].[Usuarios] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Usuario]  VARCHAR (100)  NOT NULL,
    [Password] VARBINARY (50) NOT NULL,
    [Activo]   INT            CONSTRAINT [DF_Usuarios_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

