BEGIN TRAN

CREATE TABLE [TPayment] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [UniqueId] uniqueidentifier NOT NULL,
    [UserId] int NOT NULL,
    [Amount] decimal(10,2) NOT NULL,
    [Success] bit NOT NULL,
    [Used] bit NOT NULL,
    [OrderId] int NOT NULL,
    CONSTRAINT [PK_TPayment] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211001093316_order_unique_id_added', N'3.1.7');

ROLLBACK
--COMMIT