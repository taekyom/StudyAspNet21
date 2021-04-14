CREATE TABLE [dbo].[Maxims] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (25)  NULL,
    [Contents] NVARCHAR (500) NULL,
    [RegDate]  DATETIME       NULL,
    CONSTRAINT [PK_Maxims] PRIMARY KEY CLUSTERED ([Id] ASC)
);

