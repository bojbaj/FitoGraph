BEGIN TRAN

ALTER TABLE [TUser] ADD [Lat] decimal(11,8) NOT NULL DEFAULT 0.0;
ALTER TABLE [TUser] ADD [Lng] decimal(11,8) NOT NULL DEFAULT 0.0;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210925144014_supplier_map_detail_column', N'3.1.7');

ROLLBACK
--COMMIT