BEGIN TRAN

ALTER TABLE [TFood] ADD [Tags] nvarchar(max) NULL;

CREATE TABLE [TFoodAllergy] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TFoodId] int NOT NULL,
    [TAllergyId] int NOT NULL,
    CONSTRAINT [PK_TFoodAllergy] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TFoodAllergy_TAllergy_TAllergyId] FOREIGN KEY ([TAllergyId]) REFERENCES [TAllergy] ([Id]),
    CONSTRAINT [FK_TFoodAllergy_TFood_TFoodId] FOREIGN KEY ([TFoodId]) REFERENCES [TFood] ([Id])
);

CREATE TABLE [TFoodDeficiency] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TFoodId] int NOT NULL,
    [TDeficiencyId] int NOT NULL,
    CONSTRAINT [PK_TFoodDeficiency] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TFoodDeficiency_TDeficiency_TDeficiencyId] FOREIGN KEY ([TDeficiencyId]) REFERENCES [TDeficiency] ([Id]),
    CONSTRAINT [FK_TFoodDeficiency_TFood_TFoodId] FOREIGN KEY ([TFoodId]) REFERENCES [TFood] ([Id])
);

CREATE TABLE [TFoodDiet] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TFoodId] int NOT NULL,
    [TDietId] int NOT NULL,
    CONSTRAINT [PK_TFoodDiet] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TFoodDiet_TDiet_TDietId] FOREIGN KEY ([TDietId]) REFERENCES [TDiet] ([Id]),
    CONSTRAINT [FK_TFoodDiet_TFood_TFoodId] FOREIGN KEY ([TFoodId]) REFERENCES [TFood] ([Id])
);

CREATE TABLE [TFoodNutritionCondition] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TFoodId] int NOT NULL,
    [TNutritionConditionId] int NOT NULL,
    CONSTRAINT [PK_TFoodNutritionCondition] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TFoodNutritionCondition_TFood_TFoodId] FOREIGN KEY ([TFoodId]) REFERENCES [TFood] ([Id]),
    CONSTRAINT [FK_TFoodNutritionCondition_TNutritionCondition_TNutritionConditionId] FOREIGN KEY ([TNutritionConditionId]) REFERENCES [TNutritionCondition] ([Id])
);

CREATE INDEX [IX_TFoodAllergy_TAllergyId] ON [TFoodAllergy] ([TAllergyId]);
CREATE INDEX [IX_TFoodAllergy_TFoodId] ON [TFoodAllergy] ([TFoodId]);
CREATE INDEX [IX_TFoodDeficiency_TDeficiencyId] ON [TFoodDeficiency] ([TDeficiencyId]);
CREATE INDEX [IX_TFoodDeficiency_TFoodId] ON [TFoodDeficiency] ([TFoodId]);
CREATE INDEX [IX_TFoodDiet_TDietId] ON [TFoodDiet] ([TDietId]);
CREATE INDEX [IX_TFoodDiet_TFoodId] ON [TFoodDiet] ([TFoodId]);
CREATE INDEX [IX_TFoodNutritionCondition_TFoodId] ON [TFoodNutritionCondition] ([TFoodId]);
CREATE INDEX [IX_TFoodNutritionCondition_TNutritionConditionId] ON [TFoodNutritionCondition] ([TNutritionConditionId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201207103619_food_extra_data', N'3.1.7');


ROLLBACK
--COMMIT