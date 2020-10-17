BEGIN TRAN

ALTER TABLE [TUser] ADD [TargetWeight] decimal(6,2) NOT NULL DEFAULT 0.0;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201017080600_user_target_goal', N'3.1.7');

ROLLBACK
--COMMIT