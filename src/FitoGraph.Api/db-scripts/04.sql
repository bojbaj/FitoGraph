BEGIN TRAN

IF NOT EXISTS (SELECT 1 FROM  TRegionCountry)
BEGIN
    SET IDENTITY_INSERT TRegionCountry ON
    INSERT INTO TRegionCountry 
    (id, Title, Created, Enabled)
    VALUES 
    (1, 'Country No.1', GETDATE(), 1),
    (2, 'Country No.2', GETDATE(), 1),
    (3, 'Country No.3', GETDATE(), 1)
    SET IDENTITY_INSERT TRegionCountry OFF
END
SELECT * FROM TRegionCountry

IF NOT EXISTS (SELECT 1 FROM  TRegionState)
BEGIN
    INSERT INTO TRegionState 
    (TRegionCountryId, Title, Created, Enabled)
    VALUES 
    (1, 'State No.1', GETDATE(), 1),
    (1, 'State No.2', GETDATE(), 1),
    (1, 'State No.3', GETDATE(), 1),
    (1, 'State No.4', GETDATE(), 1),
    (2, 'State No.5', GETDATE(), 1),
    (2, 'State No.6', GETDATE(), 1),
    (2, 'State No.7', GETDATE(), 1),
    (2, 'State No.8', GETDATE(), 1),
    (3, 'State No.9', GETDATE(), 1)
END
SELECT * FROM TRegionState

IF NOT EXISTS (SELECT 1 FROM  TRegionCity)
BEGIN
    INSERT INTO TRegionCity 
    (TRegionStateId, Title, Created, Enabled)
    VALUES 
    ((SELECT TOP 1 id FROM TRegionState ORDER BY NEWID()), 'City No.1', GETDATE(), 1),
    ((SELECT TOP 1 id FROM TRegionState ORDER BY NEWID()), 'City No.2', GETDATE(), 1),
    ((SELECT TOP 1 id FROM TRegionState ORDER BY NEWID()), 'City No.3', GETDATE(), 1),
    ((SELECT TOP 1 id FROM TRegionState ORDER BY NEWID()), 'City No.4', GETDATE(), 1),
    ((SELECT TOP 1 id FROM TRegionState ORDER BY NEWID()), 'City No.5', GETDATE(), 1),
    ((SELECT TOP 1 id FROM TRegionState ORDER BY NEWID()), 'City No.6', GETDATE(), 1),
    ((SELECT TOP 1 id FROM TRegionState ORDER BY NEWID()), 'City No.7', GETDATE(), 1),
    ((SELECT TOP 1 id FROM TRegionState ORDER BY NEWID()), 'City No.8', GETDATE(), 1),
    ((SELECT TOP 1 id FROM TRegionState ORDER BY NEWID()), 'City No.9', GETDATE(), 1)
END
SELECT * FROM TRegionCity


ROLLBACK
--COMMIT