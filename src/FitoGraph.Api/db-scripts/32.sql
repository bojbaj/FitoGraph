BEGIN TRAN

CREATE TABLE [TOrder] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Code] nvarchar(max) NULL,
    [Date] datetime2 NOT NULL,
    [TotalPayablePrice] decimal(10,2) NOT NULL,
    [TUserId] int NOT NULL,
    [TSupplierId] int NOT NULL,
    CONSTRAINT [PK_TOrder] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TOrder_TUser_TSupplierId] FOREIGN KEY ([TSupplierId]) REFERENCES [TUser] ([Id]),
    CONSTRAINT [FK_TOrder_TUser_TUserId] FOREIGN KEY ([TUserId]) REFERENCES [TUser] ([Id])
);

CREATE TABLE [TOrderDetail] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TFoodId] int NOT NULL,
    [Amount] int NOT NULL,
    [UnitPrice] decimal(10,2) NOT NULL,
    [RowPrice] decimal(10,2) NOT NULL,
    [TUserId] int NOT NULL,
    [TOrderId] int NOT NULL,
    CONSTRAINT [PK_TOrderDetail] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TOrderDetail_TFood_TFoodId] FOREIGN KEY ([TFoodId]) REFERENCES [TFood] ([Id]),
    CONSTRAINT [FK_TOrderDetail_TOrder_TOrderId] FOREIGN KEY ([TOrderId]) REFERENCES [TOrder] ([Id]),
    CONSTRAINT [FK_TOrderDetail_TUser_TUserId] FOREIGN KEY ([TUserId]) REFERENCES [TUser] ([Id])
);

CREATE INDEX [IX_TOrder_TSupplierId] ON [TOrder] ([TSupplierId]);
CREATE INDEX [IX_TOrder_TUserId] ON [TOrder] ([TUserId]);
CREATE INDEX [IX_TOrderDetail_TFoodId] ON [TOrderDetail] ([TFoodId]);
CREATE INDEX [IX_TOrderDetail_TOrderId] ON [TOrderDetail] ([TOrderId]);
CREATE INDEX [IX_TOrderDetail_TUserId] ON [TOrderDetail] ([TUserId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210701083253_order_tables', N'3.1.7');

ROLLBACK
--COMMIT