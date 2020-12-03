BEGIN TRAN

CREATE TABLE [TReferenceInRange] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    [Gender] int NOT NULL,
    [FromAge] int NOT NULL,
    [ToAge] int NOT NULL,
    [TReferenceId] int NULL,
    CONSTRAINT [PK_TReferenceInRange] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TReferenceInRange_TReference_TReferenceId] FOREIGN KEY ([TReferenceId]) REFERENCES [TReference] ([Id])
);

CREATE INDEX [IX_TReferenceInRange_TReferenceId] ON [TReferenceInRange] ([TReferenceId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201203071000_reference_range', N'3.1.7');


ROLLBACK
--COMMIT