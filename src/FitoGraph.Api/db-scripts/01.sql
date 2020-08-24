BEGIN TRAN

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

CREATE TABLE [TActivityLevel] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    [Note] nvarchar(max) NULL,
    [PALForMale] float NOT NULL,
    [PALForFeMale] float NOT NULL,
    [Protein] float NOT NULL,
    [Carb] float NOT NULL,
    CONSTRAINT [PK_TActivityLevel] PRIMARY KEY ([Id])
);

CREATE TABLE [TAllergy] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_TAllergy] PRIMARY KEY ([Id])
);

CREATE TABLE [TBodyType] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_TBodyType] PRIMARY KEY ([Id])
);

CREATE TABLE [TDeficiency] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_TDeficiency] PRIMARY KEY ([Id])
);

CREATE TABLE [TDiet] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_TDiet] PRIMARY KEY ([Id])
);

CREATE TABLE [TFoodType] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_TFoodType] PRIMARY KEY ([Id])
);

CREATE TABLE [TGoal] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_TGoal] PRIMARY KEY ([Id])
);

CREATE TABLE [TNutritionCondition] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_TNutritionCondition] PRIMARY KEY ([Id])
);

CREATE TABLE [TSport] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_TSport] PRIMARY KEY ([Id])
);

CREATE TABLE [TWeeklyGoal] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TGoalId] int NOT NULL,
    [Title] nvarchar(max) NULL,
    [Note] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_TWeeklyGoal] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TWeeklyGoal_TGoal_TGoalId] FOREIGN KEY ([TGoalId]) REFERENCES [TGoal] ([Id])
);

CREATE TABLE [TUser] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [FireBaseId] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [TBodyTypeId] int NULL,
    [TActivityLevelId] int NULL,
    [TGoalId] int NULL,
    [TWeeklyGoalId] int NULL,
    CONSTRAINT [PK_TUser] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TUser_TActivityLevel_TActivityLevelId] FOREIGN KEY ([TActivityLevelId]) REFERENCES [TActivityLevel] ([Id]),
    CONSTRAINT [FK_TUser_TBodyType_TBodyTypeId] FOREIGN KEY ([TBodyTypeId]) REFERENCES [TBodyType] ([Id]),
    CONSTRAINT [FK_TUser_TGoal_TGoalId] FOREIGN KEY ([TGoalId]) REFERENCES [TGoal] ([Id]),
    CONSTRAINT [FK_TUser_TWeeklyGoal_TWeeklyGoalId] FOREIGN KEY ([TWeeklyGoalId]) REFERENCES [TWeeklyGoal] ([Id])
);

CREATE TABLE [TUserAllergy] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TUserId] int NOT NULL,
    [TAllergyId] int NOT NULL,
    CONSTRAINT [PK_TUserAllergy] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TUserAllergy_TAllergy_TAllergyId] FOREIGN KEY ([TAllergyId]) REFERENCES [TAllergy] ([Id]),
    CONSTRAINT [FK_TUserAllergy_TUser_TUserId] FOREIGN KEY ([TUserId]) REFERENCES [TUser] ([Id])
);

CREATE TABLE [TUserDeficiency] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TUserId] int NOT NULL,
    [TDeficiencyId] int NOT NULL,
    CONSTRAINT [PK_TUserDeficiency] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TUserDeficiency_TDeficiency_TDeficiencyId] FOREIGN KEY ([TDeficiencyId]) REFERENCES [TDeficiency] ([Id]),
    CONSTRAINT [FK_TUserDeficiency_TUser_TUserId] FOREIGN KEY ([TUserId]) REFERENCES [TUser] ([Id])
);

CREATE TABLE [TUserDiet] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TUserId] int NOT NULL,
    [TDietId] int NOT NULL,
    CONSTRAINT [PK_TUserDiet] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TUserDiet_TDiet_TDietId] FOREIGN KEY ([TDietId]) REFERENCES [TDiet] ([Id]),
    CONSTRAINT [FK_TUserDiet_TUser_TUserId] FOREIGN KEY ([TUserId]) REFERENCES [TUser] ([Id])
);

CREATE TABLE [TUserFoodType] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TUserId] int NOT NULL,
    [TFoodTypeId] int NOT NULL,
    CONSTRAINT [PK_TUserFoodType] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TUserFoodType_TFoodType_TFoodTypeId] FOREIGN KEY ([TFoodTypeId]) REFERENCES [TFoodType] ([Id]),
    CONSTRAINT [FK_TUserFoodType_TUser_TUserId] FOREIGN KEY ([TUserId]) REFERENCES [TUser] ([Id])
);

CREATE TABLE [TUserNutritionCondition] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TUserId] int NOT NULL,
    [TNutritionConditionId] int NOT NULL,
    CONSTRAINT [PK_TUserNutritionCondition] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TUserNutritionCondition_TNutritionCondition_TNutritionConditionId] FOREIGN KEY ([TNutritionConditionId]) REFERENCES [TNutritionCondition] ([Id]),
    CONSTRAINT [FK_TUserNutritionCondition_TUser_TUserId] FOREIGN KEY ([TUserId]) REFERENCES [TUser] ([Id])
);

CREATE TABLE [TUserSport] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TUserId] int NOT NULL,
    [TSportId] int NOT NULL,
    CONSTRAINT [PK_TUserSport] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TUserSport_TSport_TSportId] FOREIGN KEY ([TSportId]) REFERENCES [TSport] ([Id]),
    CONSTRAINT [FK_TUserSport_TUser_TUserId] FOREIGN KEY ([TUserId]) REFERENCES [TUser] ([Id])
);

CREATE INDEX [IX_TUser_TActivityLevelId] ON [TUser] ([TActivityLevelId]);

CREATE INDEX [IX_TUser_TBodyTypeId] ON [TUser] ([TBodyTypeId]);

CREATE INDEX [IX_TUser_TGoalId] ON [TUser] ([TGoalId]);

CREATE INDEX [IX_TUser_TWeeklyGoalId] ON [TUser] ([TWeeklyGoalId]);

CREATE INDEX [IX_TUserAllergy_TAllergyId] ON [TUserAllergy] ([TAllergyId]);

CREATE INDEX [IX_TUserAllergy_TUserId] ON [TUserAllergy] ([TUserId]);

CREATE INDEX [IX_TUserDeficiency_TDeficiencyId] ON [TUserDeficiency] ([TDeficiencyId]);

CREATE INDEX [IX_TUserDeficiency_TUserId] ON [TUserDeficiency] ([TUserId]);

CREATE INDEX [IX_TUserDiet_TDietId] ON [TUserDiet] ([TDietId]);

CREATE INDEX [IX_TUserDiet_TUserId] ON [TUserDiet] ([TUserId]);

CREATE INDEX [IX_TUserFoodType_TFoodTypeId] ON [TUserFoodType] ([TFoodTypeId]);

CREATE INDEX [IX_TUserFoodType_TUserId] ON [TUserFoodType] ([TUserId]);

CREATE INDEX [IX_TUserNutritionCondition_TNutritionConditionId] ON [TUserNutritionCondition] ([TNutritionConditionId]);

CREATE INDEX [IX_TUserNutritionCondition_TUserId] ON [TUserNutritionCondition] ([TUserId]);

CREATE INDEX [IX_TUserSport_TSportId] ON [TUserSport] ([TSportId]);

CREATE INDEX [IX_TUserSport_TUserId] ON [TUserSport] ([TUserId]);

CREATE INDEX [IX_TWeeklyGoal_TGoalId] ON [TWeeklyGoal] ([TGoalId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200824070226_base_tables', N'3.1.7');



--ROLLBACK
COMMIT