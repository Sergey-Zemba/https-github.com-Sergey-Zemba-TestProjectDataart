USE [SZemba_Practice]
GO

/****** Object:  StoredProcedure [dbo].[article_crud]    Script Date: 15.09.2016 18:23:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[article_crud]
(
@Id INT = 0,
@Title NVARCHAR(200) = NULL,
@ShortDescriiption NVARCHAR(500) = NULL,
@Content NVARCHAR(MAX) = NULL,
@PicturePath NVARCHAR(MAX) = NULL,
@CreationDate DATETIME = NULL,
@Page INT = 1,
@Query INT = NULL
)
AS
BEGIN
DECLARE @Offset INT = (@Page - 1) * 10;
IF(@Query = 1)
BEGIN
INSERT INTO article(
Title,
ShortDescription,
Content,
PicturePath,
CreationDate
)
VALUES(
@Title,
@ShortDescriiption,
@Content,
@PicturePath,
GETDATE()
)
END

IF(@Query = 2)
BEGIN
UPDATE article
SET 
Title = @Title,
ShortDescription = @ShortDescriiption,
Content = @Content,
PicturePath = @PicturePath
WHERE article.Id = @Id
END

IF(@Query = 3)
BEGIN
DELETE 
FROM article
WHERE article.Id = @Id
END

IF(@Query = 4)
BEGIN
SELECT * FROM article
ORDER BY CreationDate DESC
OFFSET @Offset ROWS
FETCH NEXT 10 ROWS ONLY
END

IF(@Query = 5)
BEGIN
SELECT * FROM article
WHERE article.Id = @Id
END
END;
GO

