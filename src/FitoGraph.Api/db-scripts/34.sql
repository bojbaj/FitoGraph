BEGIN TRAN

ALTER TABLE [TUser] ADD [ShareAccount] nvarchar(max) NULL;
ALTER TABLE [TUser] ADD [SharePercent] decimal(6,2) NOT NULL DEFAULT 0.0;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210722101000_supplier_share_columns', N'3.1.7');

ROLLBACK
--COMMIT