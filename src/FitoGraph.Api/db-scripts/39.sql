BEGIN TRAN

ALTER TABLE [TOrder] ADD [Submited] bit NOT NULL DEFAULT CAST(0 AS bit);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211001152952_order_submitted_field_added', N'3.1.7');


ROLLBACK
--COMMIT