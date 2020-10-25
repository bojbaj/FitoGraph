BEGIN TRAN


ALTER TABLE [TUser] ADD [Role] int NOT NULL DEFAULT 0;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201025075553_user_role', N'3.1.7');

UPDATE TUser SET [Role] = 1 

ROLLBACK
--COMMIT