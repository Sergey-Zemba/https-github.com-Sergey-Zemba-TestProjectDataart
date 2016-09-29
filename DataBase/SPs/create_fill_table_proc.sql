IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='fill_table_proc')
BEGIN
EXECUTE('CREATE PROCEDURE fill_table_proc AS
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
'''Title''' + CAST(@Cur AS NVARCHAR(10)),
'''ShortDescription''' + CAST(@Cur AS NVARCHAR(10)),
'''Content''' + CAST(@Cur AS NVARCHAR(10)),
'''ImageName''' + CAST(@Cur AS NVARCHAR(10)),
GETDATE()
);
SET @Cur = @Cur + 1;
END
END'
)
END;