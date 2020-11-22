BEGIN TRAN

DECLARE @var0 sysname
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TFoodNutrition]') AND [c].[name] = N'Unit')
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TFoodNutrition] DROP CONSTRAINT [' + @var0 + '];')
ALTER TABLE [TFoodNutrition] DROP COLUMN [Unit]

ALTER TABLE [TFoodNutrition] ADD [TNutritionUnitId] int NOT NULL DEFAULT 0
ALTER TABLE [TFoodNutrition] ADD [TReferenceId] int NOT NULL DEFAULT 0

CREATE TABLE [TNutritionUnit] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    [AmountInGram] int NOT NULL,
    CONSTRAINT [PK_TNutritionUnit] PRIMARY KEY ([Id])
)

CREATE INDEX [IX_TFoodNutrition_TNutritionUnitId] ON [TFoodNutrition] ([TNutritionUnitId])
CREATE INDEX [IX_TFoodNutrition_TReferenceId] ON [TFoodNutrition] ([TReferenceId])
ALTER TABLE [TFoodNutrition] ADD CONSTRAINT [FK_TFoodNutrition_TNutritionUnit_TNutritionUnitId] FOREIGN KEY ([TNutritionUnitId]) REFERENCES [TNutritionUnit] ([Id])
ALTER TABLE [TFoodNutrition] ADD CONSTRAINT [FK_TFoodNutrition_TReference_TReferenceId] FOREIGN KEY ([TReferenceId]) REFERENCES [TReference] ([Id])

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201122154807_food_nutrition_unit', N'3.1.7');

INSERT INTO TNutritionUnit (Title, Image, Enabled, Created, AmountInGram) VALUES
('Gram', '', 1, GETDATE(), 1),
('Cup', '', 1, GETDATE(), 400),
('TSP', '', 1, GETDATE(), 4),
('TBS', '', 1, GETDATE(), 14)


ROLLBACK
--COMMIT