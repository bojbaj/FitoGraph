IF NOT EXISTS (SELECT 1 FROM sys.syscolumns  WHERE name = 'caloryRequirePercent' AND id = OBJECT_ID('TWeeklyGoal'))
BEGIN 
	ALTER TABLE TWeeklyGoal ADD caloryRequirePercent INT NOT NULL DEFAULT(0)
END
GO
UPDATE TWeeklyGoal SET caloryRequirePercent = 91 WHERE Title = 'Lose 0.25 Kg per week'
UPDATE TWeeklyGoal SET caloryRequirePercent = 81 WHERE Title = 'Lose 0.5 Kg per week'
UPDATE TWeeklyGoal SET caloryRequirePercent = 72 WHERE Title = 'Lose 0.75 Kg per week'
UPDATE TWeeklyGoal SET caloryRequirePercent = 63 WHERE Title = 'Lose 1 Kg per week'
UPDATE TWeeklyGoal SET caloryRequirePercent = 91 WHERE Title = 'Gain 0.25 Kg per week'
UPDATE TWeeklyGoal SET caloryRequirePercent = 81 WHERE Title = 'Gain 0.5 Kg per week'
UPDATE TWeeklyGoal SET caloryRequirePercent = 72 WHERE Title = 'Gain 0.75 Kg per week'
UPDATE TWeeklyGoal SET caloryRequirePercent = 63 WHERE Title = 'Gain 1 Kg per week'
UPDATE TWeeklyGoal SET caloryRequirePercent = 100 WHERE Title = 'Maintain your current weight'
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210128121247_CaloryReq_By_WeeklyGoal', N'3.1.7');

GO


