BEGIN TRAN

CREATE TABLE [TNutritionGroup] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Code] int NOT NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_TNutritionGroup] PRIMARY KEY ([Id])
);

CREATE TABLE [TReference] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [RecordId] int NOT NULL,
    [RecordType] int NOT NULL,
    [Energy] decimal(10,2) NOT NULL,
    [Protein] decimal(10,2) NOT NULL,
    [carbohydrate] decimal(10,2) NOT NULL,
    [Fat] decimal(10,2) NOT NULL,
    [Ash] decimal(10,2) NOT NULL,
    [Dietary_Fibre] decimal(10,2) NOT NULL,
    [Fructose] decimal(10,2) NOT NULL,
    [Glucose] decimal(10,2) NOT NULL,
    [Sucrose] decimal(10,2) NOT NULL,
    [Lactose] decimal(10,2) NOT NULL,
    [Total_Sugars] decimal(10,2) NOT NULL,
    [Starch] decimal(10,2) NOT NULL,
    [Calcium] decimal(10,2) NOT NULL,
    [Chloride] decimal(10,2) NOT NULL,
    [Cupper] decimal(10,2) NOT NULL,
    [Fluoride] decimal(10,2) NOT NULL,
    [Iodine] decimal(10,2) NOT NULL,
    [Iron] decimal(10,2) NOT NULL,
    [Magnesium] decimal(10,2) NOT NULL,
    [Manganese] decimal(10,2) NOT NULL,
    [Phosphorus] decimal(10,2) NOT NULL,
    [Potassium] decimal(10,2) NOT NULL,
    [Selenium] decimal(10,2) NOT NULL,
    [Sodium] decimal(10,2) NOT NULL,
    [Sulphur] decimal(10,2) NOT NULL,
    [Tin] decimal(10,2) NOT NULL,
    [Zinc] decimal(10,2) NOT NULL,
    [Alpha_Carotene] decimal(10,2) NOT NULL,
    [Beta_Carotene] decimal(10,2) NOT NULL,
    [Cryptoxanthin] decimal(10,2) NOT NULL,
    [Vitamin_A] decimal(10,2) NOT NULL,
    [Lutein] decimal(10,2) NOT NULL,
    [Lycopene] decimal(10,2) NOT NULL,
    [Thiamin_B1] decimal(10,2) NOT NULL,
    [Riboflavin_B2] decimal(10,2) NOT NULL,
    [Niacin_B3] decimal(10,2) NOT NULL,
    [Pantothenic_Acid_B5] decimal(10,2) NOT NULL,
    [Vitamin_B6] decimal(10,2) NOT NULL,
    [Biotin_B7] decimal(10,2) NOT NULL,
    [Vitamin_B12] decimal(10,2) NOT NULL,
    [Folate] decimal(10,2) NOT NULL,
    [Folic_Acid] decimal(10,2) NOT NULL,
    [Vitamin_C] decimal(10,2) NOT NULL,
    [Vitamin_D] decimal(10,2) NOT NULL,
    [Molybdenum] decimal(10,2) NOT NULL,
    [Chromium] decimal(10,2) NOT NULL,
    [Vitamin_E] decimal(10,2) NOT NULL,
    [Total_Saturated_Fatty_Acids] decimal(10,2) NOT NULL,
    [Total_Monounsaturated_Fatty_Acids] decimal(10,2) NOT NULL,
    [Total_Polyunsaturated_Fatty_Acids] decimal(10,2) NOT NULL,
    [Total_Long_Chain_Omega_3_Fatty_Acids] decimal(10,2) NOT NULL,
    [Total_Trans_Fatty_Acids] decimal(10,2) NOT NULL,
    [Caffeine] decimal(10,2) NOT NULL,
    [Cholesterol] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_TReference] PRIMARY KEY ([Id])
);

CREATE TABLE [TFood] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    [TReferenceId] int NOT NULL,
    [TFoodTypeId] int NOT NULL,
    CONSTRAINT [PK_TFood] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TFood_TFoodType_TFoodTypeId] FOREIGN KEY ([TFoodTypeId]) REFERENCES [TFoodType] ([Id]),
    CONSTRAINT [FK_TFood_TReference_TReferenceId] FOREIGN KEY ([TReferenceId]) REFERENCES [TReference] ([Id])
);

CREATE TABLE [TNutrition] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Code] nvarchar(450) NULL,
    [Image] nvarchar(max) NULL,
    [TNutritionGroupId] int NOT NULL,
    [TReferenceId] int NOT NULL,
    CONSTRAINT [PK_TNutrition] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TNutrition_TNutritionGroup_TNutritionGroupId] FOREIGN KEY ([TNutritionGroupId]) REFERENCES [TNutritionGroup] ([Id]),
    CONSTRAINT [FK_TNutrition_TReference_TReferenceId] FOREIGN KEY ([TReferenceId]) REFERENCES [TReference] ([Id])
);

CREATE TABLE [TFoodNutrition] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [TFoodId] int NOT NULL,
    [TNutritionId] int NOT NULL,
    [Unit] int NOT NULL,
    [Amount] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_TFoodNutrition] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TFoodNutrition_TFood_TFoodId] FOREIGN KEY ([TFoodId]) REFERENCES [TFood] ([Id]),
    CONSTRAINT [FK_TFoodNutrition_TNutrition_TNutritionId] FOREIGN KEY ([TNutritionId]) REFERENCES [TNutrition] ([Id])
);

CREATE INDEX [IX_TFood_TFoodTypeId] ON [TFood] ([TFoodTypeId]);
CREATE INDEX [IX_TFood_TReferenceId] ON [TFood] ([TReferenceId]);
CREATE INDEX [IX_TFoodNutrition_TFoodId] ON [TFoodNutrition] ([TFoodId]);
CREATE INDEX [IX_TFoodNutrition_TNutritionId] ON [TFoodNutrition] ([TNutritionId]);
CREATE UNIQUE INDEX [UQ_TNutrition_Code] ON [TNutrition] ([Code]) WHERE [Code] IS NOT NULL;
CREATE INDEX [IX_TNutrition_TNutritionGroupId] ON [TNutrition] ([TNutritionGroupId]);
CREATE INDEX [IX_TNutrition_TReferenceId] ON [TNutrition] ([TReferenceId]);
CREATE UNIQUE INDEX [UQ_TNutritionGroup_Code] ON [TNutritionGroup] ([Code]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201110140052_food_nutrition', N'3.1.7');


ROLLBACK
--COMMIT