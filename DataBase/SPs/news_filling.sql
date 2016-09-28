IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[news_filling]') AND type in (N'P', N'PC'))
AND EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME='News')
DROP PROCEDURE news_filling;
CREATE PROCEDURE news_filling AS
BEGIN
DECLARE @Cur INT = 1;
WHILE(@Cur<=100)
BEGIN
INSERT INTO News(
Title,
ShortDescription,
Content,
ImageName,
CreationDate
)
VALUES(
'Title' + CAST(@Cur AS NVARCHAR(10)),
'ShortDescriiption' + CAST(@Cur AS NVARCHAR(10)),
'Content' + CAST(@Cur AS NVARCHAR(10)),
'ImageName' + CAST(@Cur AS NVARCHAR(10)),
GETDATE()
)
SET @Cur = @Cur + 1;
END
END;
EXEC news_filling;