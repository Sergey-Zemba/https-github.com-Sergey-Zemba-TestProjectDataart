CREATE PROCEDURE [dbo].[article_delete]
(
@Id INT = 0
)
AS
BEGIN
DELETE 
FROM article
WHERE article.Id = @Id
END