BEGIN TRAN

ALTER TABLE [TUser] ADD [Address] nvarchar(max) NULL;

ALTER TABLE [TUser] ADD [PostalCode] nvarchar(max) NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201008131853_user_postal_address_added', N'3.1.7');

ROLLBACK
--COMMIT