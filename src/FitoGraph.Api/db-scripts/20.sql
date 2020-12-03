BEGIN TRAN


DECLARE @TReferenceId INT
DECLARE @TReferenceInRangeId INT

--Children		1y	3y
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    14, 0.5, 0.5, 6, 0.5, 0.9, 150, 3.5, 8, 300, 35, 5, 5, 500, 460, 3, 9, 80, 90, 25, 17, 0.7, 11, 2, 0.6, 200, 2000, 
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Children boys 1-3', 1, 1, 3, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    14, 0.5, 0.5, 6, 0.5, 0.9, 150, 3.5, 8, 300, 35, 5, 5, 500, 460, 3, 9, 80, 90, 25, 17, 0.7, 11, 2, 0.6, 200, 2000, 
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Children girls 1-3', 2, 1, 3, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId


--Children		4y	8y
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    18, 0.6, 0.6, 8, 0.6, 1.2, 200, 4, 12, 400, 35, 5, 6, 700, 500, 4, 10, 130, 90, 30, 22, 1, 15, 2.5, 1.1, 300, 2300,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Children boys 4-8', 1, 4, 8, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    18, 0.6, 0.6, 8, 0.6, 1.2, 200, 4, 12, 400, 35, 5, 6, 700, 500, 4, 10, 130, 90, 30, 22, 1, 15, 2.5, 1.1, 300, 2300,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Children girls 4-8', 2, 4, 8, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

--Boys	male	9y	13y
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    24, 0.9, 0.9, 12, 1, 1.8, 300, 5, 20, 600, 40, 5, 9, 1000, 1250, 6, 8, 240, 120, 50, 34, 1.3, 25, 3, 2, 400, 3000,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Boys 9-13', 1, 9, 13, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

--Boys	male	14y	18y
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    28, 1.2, 1.3, 16, 1.3, 2.4, 400, 6, 30, 900, 40, 5, 10, 1300, 1250, 13, 11, 410, 150, 70, 43, 1.5, 35, 3.5, 3, 460, 3600,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Boys 14-18', 1, 14, 18, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

-- Girls	female	9y	13y
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    20, 0.9, 0.9, 12, 1, 1.8, 300, 4, 20, 600, 40, 5, 8, 1000, 1250, 6, 8, 240, 120, 50, 34, 1.1, 21, 2.5, 2, 400, 2500,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Girls 9-13', 2, 9, 13, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId


-- Girls	female	14y	18y
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    22, 1.1, 1.1, 14, 1.2, 2.4, 400, 4, 25, 700, 40, 5, 8, 1300, 1250, 7, 15, 360, 150, 60, 43, 1.1, 24, 3, 3, 460, 2600,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Girls 14-18', 2, 14, 18, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

-- Men	male	19y	30y
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    30, 1.2, 1.3, 16, 1.3, 2.4, 400, 6, 30, 900, 45, 5, 10, 1000, 1000, 14, 8, 400, 150, 70, 45, 1.7, 35, 5.5, 4, 460, 3800,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Men 19-30', 1, 19, 30, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

-- Men	male	31y	50y
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    30, 1.2, 1.3, 16, 1.3, 2.4, 400, 6, 30, 900, 45, 5, 10, 1000, 1000, 14, 8, 420, 150, 70, 45, 1.7, 35, 5.5, 4, 460, 3800,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Men 31-50', 1, 31, 50, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

-- Men	male	51y	70y
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    30, 1.2, 1.3, 16, 1.7, 2.4, 400, 6, 30, 900, 45, 10, 10, 1000, 1000, 14, 8, 420, 150, 70, 45, 1.7, 35, 5.5, 4, 460, 3800,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Men 51-70', 1, 51, 70, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

-- Men	male	71y	
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    30, 1.2, 1.6, 16, 1.7, 2.4, 400, 6, 30, 900, 45, 15, 10, 1300, 1000, 14, 8, 420, 150, 70, 45, 1.7, 35, 5.5, 4, 460, 3800,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Men 71-200', 1, 71, 200, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

-- Women	female	19y	30y
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    25, 1.1, 1.1, 14, 1.3, 2.4, 400, 4, 25, 700, 45, 5, 7, 1000, 1000, 8, 18, 310, 150, 60, 45, 1.2, 25, 5, 3, 460, 2800,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Women 19-30', 2, 19, 30, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

-- Women	female	31y	50y
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    25, 1.1, 1.1, 14, 1.3, 2.4, 400, 4, 25, 700, 45, 5, 7, 1000, 1000, 8, 18, 320, 150, 60, 45, 1.2, 25, 5, 3, 460, 2800,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Women 31-50', 2, 31, 50, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

-- Women	female	51y	70y
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    25, 1.1, 1.1, 14, 1.5, 2.4, 400, 4, 25, 700, 45, 10, 7, 1300, 1000, 8, 8, 320, 150, 60, 45, 1.2, 25, 5, 3, 460, 2800,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Women 51-70', 2, 51, 70, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId

-- Women	female	71y	
INSERT INTO TReference (
    [Dietary_Fibre], [Thiamin_B1], [Riboflavin_B2], [Niacin_B3], [Vitamin_B6], [Vitamin_B12], [Folate], [Pantothenic_acid_B5],
    [Biotin_B7], [Vitamin_A], [Vitamin_C], [Vitamin_D], [Vitamin_E], [Calcium], [Phosphorus], [Zinc], [Iron], [Magnesium], [Iodine],
    [Selenium], [Molybdenum], [Copper], [Chromium], [Manganese], [Fluoride], [Sodium], [Potassium], 
    [Energy], [Protein], [carbohydrate], [Fat], [Ash], [Fructose], [Glucose], [Sucrose], [Lactose], [Total_sugars], 
    [Starch], [Chloride], [Sulphur], [Tin], [Alpha_carotene], [Beta_carotene], [Cryptoxanthin], [Lutein], [Lycopene], 
    [Folic_acid], [Total_saturated_fatty_acids], [Total_monounsaturated_fatty_acids], [Total_polyunsaturated_fatty_acids], 
    [Total_long_chain_omega_3_fatty_acids], [Total_trans_fatty_acids], [Caffeine], [Cholesterol], 
    [RecordType], [RecordId], [Enabled], [Created])
VALUES(
    25, 1.1, 1.3, 14, 1.5, 2.4, 400, 4, 25, 700, 45, 15, 7, 1300, 1000, 8, 8, 320, 150, 60, 45, 1.2, 25, 5, 3, 460, 2800,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    6, 0, 1, GETDATE())
SET @TReferenceId = SCOPE_IDENTITY()
INSERT INTO [TReferenceInRange] ([Title], [Gender], [FromAge], [ToAge], [TReferenceId], [Enabled], [Created])
VALUES ('Women 71-200', 2, 71, 200, @TReferenceId, 1, GETDATE())
SET @TReferenceInRangeId = SCOPE_IDENTITY()
UPDATE TReference SET RecordId = @TReferenceInRangeId WHERE id = @TReferenceId



SELECT * FROM TReferenceInRange
SELECT * FROM TReference WHERE RecordType = 6

ROLLBACK
--COMMIT