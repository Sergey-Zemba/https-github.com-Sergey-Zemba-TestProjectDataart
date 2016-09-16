USE SZemba_Practice;
GO

DECLARE @n INT = 1;
WHILE @n<173
BEGIN
INSERT INTO article
VALUES
(
'Title' + CAST(@n AS nvarchar(3)),
'ShortDescription' + CAST(@n AS nvarchar(3)),
'Content' + CAST(@n AS nvarchar(3)),
'PicturePath' + CAST(@n AS nvarchar(3)),
GETDATE()
);
SET @n = @n + 1;
END;