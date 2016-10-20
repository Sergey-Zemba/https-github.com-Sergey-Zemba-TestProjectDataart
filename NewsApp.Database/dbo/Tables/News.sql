CREATE TABLE [dbo].[News] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Title]            NVARCHAR (200) NOT NULL,
    [ShortDescription] NVARCHAR (50)  NOT NULL,
    [Content]          NVARCHAR (MAX) NOT NULL,
    [ImageName]        NVARCHAR (MAX) NOT NULL,
    [CreationDate]     DATETIME       NOT NULL,
    [TestColumn] NVARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

