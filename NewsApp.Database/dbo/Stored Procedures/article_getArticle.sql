CREATE PROCEDURE [dbo].[article_getArticle]
(
@Id INT = 0
)
AS
BEGIN
SELECT * FROM article
WHERE article.Id = @Id
END