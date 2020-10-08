BEGIN TRAN


ALTER TABLE [TUser] ADD [TRegionCityId] int NULL;


CREATE TABLE [TRegionCountry] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_TRegionCountry] PRIMARY KEY ([Id])
);


CREATE TABLE [TRegionState] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    [TRegionCountryId] int NOT NULL,
    CONSTRAINT [PK_TRegionState] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TRegionState_TRegionCountry_TRegionCountryId] FOREIGN KEY ([TRegionCountryId]) REFERENCES [TRegionCountry] ([Id])
);


CREATE TABLE [TRegionCity] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    [TRegionStateId] int NOT NULL,
    CONSTRAINT [PK_TRegionCity] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TRegionCity_TRegionState_TRegionStateId] FOREIGN KEY ([TRegionStateId]) REFERENCES [TRegionState] ([Id])
);


CREATE INDEX [IX_TUser_TRegionCityId] ON [TUser] ([TRegionCityId]);


CREATE INDEX [IX_TRegionCity_TRegionStateId] ON [TRegionCity] ([TRegionStateId]);


CREATE INDEX [IX_TRegionState_TRegionCountryId] ON [TRegionState] ([TRegionCountryId]);


ALTER TABLE [TUser] ADD CONSTRAINT [FK_TUser_TRegionCity_TRegionCityId] FOREIGN KEY ([TRegionCityId]) REFERENCES [TRegionCity] ([Id]);


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201008093902_region_tables', N'3.1.7');


ROLLBACK
--COMMIT