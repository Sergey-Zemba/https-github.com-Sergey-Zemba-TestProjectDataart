IF EXISTS (SELECT * FROM sys.objects WHERE id = object_id(N'[dbo].[fill_table_proc]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
EXECUTE ('DROP PROCEDURE [dbo].[fill_table_proc];
CREATE PROCEDURE [dbo].[fill_table_proc] AS
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
''Title'' + CAST(@Cur AS NVARCHAR(10)),
''ShortDescriiption'' + CAST(@Cur AS NVARCHAR(10)),
''Content'' + CAST(@Cur AS NVARCHAR(10)),
''ImageName'' + CAST(@Cur AS NVARCHAR(10)),
GETDATE()
);
SET @Cur = @Cur + 1;
END
END;')
END;