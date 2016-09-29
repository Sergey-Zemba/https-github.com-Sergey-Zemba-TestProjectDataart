IF NOT EXISTS (SELECT * FROM sysobjects WHERE object_id = OBJECT_ID(N'fill_table_proc') AND type in (N'P', N'PC'))
BEGIN
CREATE PROCEDURE fill_table_proc AS
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
);
SET @Cur = @Cur + 1;
END
END
END;
