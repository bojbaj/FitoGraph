BEGIN TRAN

ALTER TABLE [TReference] ADD [Calorie] decimal(10,2) NOT NULL DEFAULT 0.0;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201212104829_reference_calorie', N'3.1.7');

ROLLBACK
--COMMIT