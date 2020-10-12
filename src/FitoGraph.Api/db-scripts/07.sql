BEGIN TRAN


ALTER TABLE [TUser] ADD [Fat] decimal(6,2) NOT NULL DEFAULT 0.0;
ALTER TABLE [TUser] ADD [Forearms] decimal(6,2) NOT NULL DEFAULT 0.0;
ALTER TABLE [TUser] ADD [Height] decimal(6,2) NOT NULL DEFAULT 0.0;
ALTER TABLE [TUser] ADD [Hips] decimal(6,2) NOT NULL DEFAULT 0.0;
ALTER TABLE [TUser] ADD [Waist] decimal(6,2) NOT NULL DEFAULT 0.0;
ALTER TABLE [TUser] ADD [Weight] decimal(6,2) NOT NULL DEFAULT 0.0;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201012124423_user_body_info', N'3.1.7');


ROLLBACK
--COMMIT