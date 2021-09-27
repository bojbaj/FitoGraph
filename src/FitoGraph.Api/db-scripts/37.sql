BEGIN TRAN

ALTER TABLE [TArticle] ADD [Summary] nvarchar(max) NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210927125339_articles_summary_added', N'3.1.7');

ROLLBACK
--COMMIT