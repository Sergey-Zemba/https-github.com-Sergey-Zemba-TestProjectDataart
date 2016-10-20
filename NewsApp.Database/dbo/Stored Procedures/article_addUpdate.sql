CREATE PROCEDURE [dbo].[article_addUpdate]
(
@Id INT = 0,
@Title NVARCHAR(200) = NULL,
@ShortDescriiption NVARCHAR(500) = NULL,
@Content NVARCHAR(MAX) = NULL,
@ImageName NVARCHAR(MAX) = NULL
)
AS
BEGIN
IF(@Id = 0)
BEGIN
INSERT INTO article(
Title,
ShortDescription,
Content,
ImageName,
CreationDate
)
VALUES(
@Title,
@ShortDescriiption,
@Content,
@ImageName,
GETDATE()
)
SELECT * FROM article
WHERE article.Id = IDENT_CURRENT('article')
END

ELSE
BEGIN
UPDATE article
SET 
Title = @Title,
ShortDescription = @ShortDescriiption,
Content = @Content,
ImageName = @ImageName
WHERE article.Id = @Id
SELECT * FROM article
WHERE article.Id = @Id
END
END