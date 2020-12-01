BEGIN TRAN

ALTER TABLE [TUser] ADD [TReferenceId] int NULL;
CREATE INDEX [IX_TUser_TReferenceId] ON [TUser] ([TReferenceId]);
ALTER TABLE [TUser] ADD CONSTRAINT [FK_TUser_TReference_TReferenceId] FOREIGN KEY ([TReferenceId]) REFERENCES [TReference] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201130123357_user_gfactor', N'3.1.7');

ROLLBACK
--COMMIT