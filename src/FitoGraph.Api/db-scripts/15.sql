BEGIN TRAN

ALTER TABLE [TFood] ADD [TUserId] int NOT NULL DEFAULT 0;
CREATE INDEX [IX_TFood_TUserId] ON [TFood] ([TUserId]);

ALTER TABLE [TFood] ADD CONSTRAINT [FK_TFood_TUser_TUserId] FOREIGN KEY ([TUserId]) REFERENCES [TUser] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201123084203_food_user_relation', N'3.1.7');

ROLLBACK
--COMMIT