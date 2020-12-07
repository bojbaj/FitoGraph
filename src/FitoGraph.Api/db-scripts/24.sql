BEGIN TRAN

ALTER TABLE [TFood] ADD [Price] decimal(10,2) NOT NULL DEFAULT 0.0;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201207110623_food_price', N'3.1.7');


ROLLBACK
--COMMIT