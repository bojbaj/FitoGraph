BEGIN TRAN

ALTER TABLE [TOrder] ADD [TrackingCode] nvarchar(max) NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210706142724_order_track_code', N'3.1.7');

ROLLBACK
--COMMIT