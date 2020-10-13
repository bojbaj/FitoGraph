BEGIN TRAN

ALTER TABLE [TUser] ADD [Gender] int NOT NULL DEFAULT 0;

DECLARE @var0 sysname
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TActivityLevel]') AND [c].[name] = N'Protein')
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TActivityLevel] DROP CONSTRAINT [' + @var0 + ']')
ALTER TABLE [TActivityLevel] ALTER COLUMN [Protein] decimal(6,2) NOT NULL;

DECLARE @var1 sysname
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TActivityLevel]') AND [c].[name] = N'PALForMale')
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TActivityLevel] DROP CONSTRAINT [' + @var1 + ']')
ALTER TABLE [TActivityLevel] ALTER COLUMN [PALForMale] decimal(6,2) NOT NULL;

DECLARE @var2 sysname
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TActivityLevel]') AND [c].[name] = N'PALForFeMale')
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TActivityLevel] DROP CONSTRAINT [' + @var2 + ']')
ALTER TABLE [TActivityLevel] ALTER COLUMN [PALForFeMale] decimal(6,2) NOT NULL;

DECLARE @var3 sysname
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TActivityLevel]') AND [c].[name] = N'Carb')
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [TActivityLevel] DROP CONSTRAINT [' + @var3 + ']')
ALTER TABLE [TActivityLevel] ALTER COLUMN [Carb] decimal(6,2) NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201013075920_user_gender', N'3.1.7');


--ROLLBACK
COMMIT