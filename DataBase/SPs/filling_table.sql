IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[filling_table]') AND type in (N'P', N'PC'))
AND EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME='News')
CREATE PROCEDURE [dbo].[filling_table] AS
BEGIN
EXEC create_proc;
END;