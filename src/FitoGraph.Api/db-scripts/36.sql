BEGIN TRAN

CREATE TABLE [TArticle] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Content] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_TArticle] PRIMARY KEY ([Id])
);

CREATE TABLE [TArticleSport] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TArticleId] int NOT NULL,
    [TSportId] int NOT NULL,
    CONSTRAINT [PK_TArticleSport] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TArticleSport_TArticle_TArticleId] FOREIGN KEY ([TArticleId]) REFERENCES [TArticle] ([Id]),
    CONSTRAINT [FK_TArticleSport_TSport_TSportId] FOREIGN KEY ([TSportId]) REFERENCES [TSport] ([Id])
);

CREATE INDEX [IX_TArticleSport_TArticleId] ON [TArticleSport] ([TArticleId]);
CREATE INDEX [IX_TArticleSport_TSportId] ON [TArticleSport] ([TSportId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210927111843_articles_added', N'3.1.7');

ROLLBACK
--COMMIT