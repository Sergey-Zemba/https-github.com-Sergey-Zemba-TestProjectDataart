CREATE PROCEDURE [dbo].[article_getArticles]
(
@Page INT = 1
)
AS
BEGIN
DECLARE @Offset INT = (@Page - 1) * 10;
SELECT * FROM article
ORDER BY CreationDate DESC
OFFSET @Offset ROWS
FETCH NEXT 10 ROWS ONLY
END