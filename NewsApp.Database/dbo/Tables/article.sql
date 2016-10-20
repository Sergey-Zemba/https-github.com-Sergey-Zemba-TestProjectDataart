CREATE TABLE [dbo].[article] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Title]            NVARCHAR (200) NOT NULL,
    [ShortDescription] NVARCHAR (500) NOT NULL,
    [Content]          NVARCHAR (MAX) NOT NULL,
    [ImageName]        NVARCHAR (MAX) NOT NULL,
    [CreationDate]     DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

