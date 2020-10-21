BEGIN TRAN

ALTER TABLE [TUser] DROP CONSTRAINT [FK_TUser_TGoal_TGoalId];

DROP INDEX [IX_TUser_TGoalId] ON [TUser];

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TUser]') AND [c].[name] = N'TGoalId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TUser] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [TUser] DROP COLUMN [TGoalId];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201021142456_user_goal_removed', N'3.1.7');

ROLLBACK
--COMMIT