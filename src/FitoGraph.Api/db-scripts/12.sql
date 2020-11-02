BEGIN TRAN

ALTER TABLE [TUser] ADD [RestaurantName] nvarchar(max) NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201102084705_user_restaurant_name', N'3.1.7');

ROLLBACK
--COMMIT