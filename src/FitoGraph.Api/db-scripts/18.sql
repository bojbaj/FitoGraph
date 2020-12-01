BEGIN TRAN

EXEC sp_rename N'[TReference].[Cupper]', N'Copper', N'COLUMN';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201201140115_copper', N'3.1.7');

--ALTER TABLE [TReference] ADD CONSTRAINT TReference_UQ_RecordType_RecordID UNIQUE (RecordId,RecordType)


ROLLBACK
--COMMIT