CREATE PROCEDURE [dbo].[Test_proc]
(
@Id INT = 0
)
AS
BEGIN
SELECT * FROM article
WHERE article.Id = @Id
END