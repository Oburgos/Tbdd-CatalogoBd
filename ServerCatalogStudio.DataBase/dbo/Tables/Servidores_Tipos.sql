CREATE TABLE [dbo].[Servidores_Tipos] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (150) NOT NULL,
    CONSTRAINT [PK_Servidores_Tipo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

