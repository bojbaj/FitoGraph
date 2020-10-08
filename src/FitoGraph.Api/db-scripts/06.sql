BEGIN TRAN

ALTER TABLE [TUser] ADD [BirthYear] int NOT NULL DEFAULT 0;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201008150022_user_birthyear', N'3.1.7');

ROLLBACK
--COMMIT