IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spCalculateFoodRefrence')
	DROP PROCEDURE  spCalculateFoodRefrence
GO
CREATE PROCEDURE spCalculateFoodRefrence (@FoodID INT) AS
BEGIN		
	UPDATE fnr SET 
	fnr.Energy = nr.Energy * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Protein = nr.Protein * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.carbohydrate = nr.carbohydrate * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Fat = nr.Fat * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Ash = nr.Ash * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Dietary_Fibre = nr.Dietary_Fibre * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Fructose = nr.Fructose * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Glucose = nr.Glucose * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Sucrose = nr.Sucrose * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Lactose = nr.Lactose * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Total_Sugars = nr.Total_Sugars * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Starch = nr.Starch * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Calcium = nr.Calcium * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Chloride = nr.Chloride * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Copper = nr.Copper * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Fluoride = nr.Fluoride * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Iodine = nr.Iodine * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Iron = nr.Iron * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Magnesium = nr.Magnesium * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Manganese = nr.Manganese * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Phosphorus = nr.Phosphorus * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Potassium = nr.Potassium * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Selenium = nr.Selenium * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Sodium = nr.Sodium * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Sulphur = nr.Sulphur * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Tin = nr.Tin * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Zinc = nr.Zinc * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Alpha_Carotene = nr.Alpha_Carotene * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Beta_Carotene = nr.Beta_Carotene * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Cryptoxanthin = nr.Cryptoxanthin * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Vitamin_A = nr.Vitamin_A * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Lutein = nr.Lutein * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Lycopene = nr.Lycopene * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Thiamin_B1 = nr.Thiamin_B1 * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Riboflavin_B2 = nr.Riboflavin_B2 * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Niacin_B3 = nr.Niacin_B3 * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Pantothenic_Acid_B5 = nr.Pantothenic_Acid_B5 * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Vitamin_B6 = nr.Vitamin_B6 * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Biotin_B7 = nr.Biotin_B7 * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Vitamin_B12 = nr.Vitamin_B12 * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Folate = nr.Folate * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Folic_Acid = nr.Folic_Acid * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Vitamin_C = nr.Vitamin_C * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Vitamin_D = nr.Vitamin_D * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Molybdenum = nr.Molybdenum * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Chromium = nr.Chromium * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Vitamin_E = nr.Vitamin_E * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Total_Saturated_Fatty_Acids = nr.Total_Saturated_Fatty_Acids * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Total_Monounsaturated_Fatty_Acids = nr.Total_Monounsaturated_Fatty_Acids * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Total_Polyunsaturated_Fatty_Acids = nr.Total_Polyunsaturated_Fatty_Acids * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Total_Long_Chain_Omega_3_Fatty_Acids = nr.Total_Long_Chain_Omega_3_Fatty_Acids * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Total_Trans_Fatty_Acids = nr.Total_Trans_Fatty_Acids * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Caffeine = nr.Caffeine * ((tn.Amount * nu.AmountInGram) / 100),
	fnr.Cholesterol = nr.Cholesterol * ((tn.Amount * nu.AmountInGram) / 100)
	FROM TFoodNutrition tn WITH(NOLOCK)
	JOIN TNutrition n WITH(NOLOCK) ON n.Id = tn.TNutritionId
	JOIN TReference nr WITH(NOLOCK) ON nr.id = n.TReferenceId 
	JOIN TReference fnr WITH(NOLOCK) ON fnr.id = tn.TReferenceId
	JOIN TNutritionUnit nu WITH(NOLOCK) ON nu.id = tn.TNutritionUnitId 
	WHERE tn.TFoodId = @FoodID
	
	UPDATE fr SET	
	fr.Energy = s_Energy,
	fr.Protein = s_Protein,
	fr.carbohydrate = s_carbohydrate,
	fr.Fat = s_Fat,
	fr.Ash = s_Ash,
	fr.Dietary_Fibre = s_Dietary_Fibre,
	fr.Fructose = s_Fructose,
	fr.Glucose = s_Glucose,
	fr.Sucrose = s_Sucrose,
	fr.Lactose = s_Lactose,
	fr.Total_Sugars = s_Total_Sugars,
	fr.Starch = s_Starch,
	fr.Calcium = s_Calcium,
	fr.Chloride = s_Chloride,
	fr.Copper = s_Copper,
	fr.Fluoride = s_Fluoride,
	fr.Iodine = s_Iodine,
	fr.Iron = s_Iron,
	fr.Magnesium = s_Magnesium,
	fr.Manganese = s_Manganese,
	fr.Phosphorus = s_Phosphorus,
	fr.Potassium = s_Potassium,
	fr.Selenium = s_Selenium,
	fr.Sodium = s_Sodium,
	fr.Sulphur = s_Sulphur,
	fr.Tin = s_Tin,
	fr.Zinc = s_Zinc,
	fr.Alpha_Carotene = s_Alpha_Carotene,
	fr.Beta_Carotene = s_Beta_Carotene,
	fr.Cryptoxanthin = s_Cryptoxanthin,
	fr.Vitamin_A = s_Vitamin_A,
	fr.Lutein = s_Lutein,
	fr.Lycopene = s_Lycopene,
	fr.Thiamin_B1 = s_Thiamin_B1,
	fr.Riboflavin_B2 = s_Riboflavin_B2,
	fr.Niacin_B3 = s_Niacin_B3,
	fr.Pantothenic_Acid_B5 = s_Pantothenic_Acid_B5,
	fr.Vitamin_B6 = s_Vitamin_B6,
	fr.Biotin_B7 = s_Biotin_B7,
	fr.Vitamin_B12 = s_Vitamin_B12,
	fr.Folate = s_Folate,
	fr.Folic_Acid = s_Folic_Acid,
	fr.Vitamin_C = s_Vitamin_C,
	fr.Vitamin_D = s_Vitamin_D,
	fr.Molybdenum = s_Molybdenum,
	fr.Chromium = s_Chromium,
	fr.Vitamin_E = s_Vitamin_E,
	fr.Total_Saturated_Fatty_Acids = s_Total_Saturated_Fatty_Acids,
	fr.Total_Monounsaturated_Fatty_Acids = s_Total_Monounsaturated_Fatty_Acids,
	fr.Total_Polyunsaturated_Fatty_Acids = s_Total_Polyunsaturated_Fatty_Acids,
	fr.Total_Long_Chain_Omega_3_Fatty_Acids = s_Total_Long_Chain_Omega_3_Fatty_Acids,
	fr.Total_Trans_Fatty_Acids = s_Total_Trans_Fatty_Acids,
	fr.Caffeine = s_Caffeine,
	fr.Cholesterol = s_Cholesterol
	FROM TFood t WITH(NOLOCK)
	JOIN TReference fr WITH(NOLOCK) ON t.TReferenceId = fr.Id 
	JOIN (
		SELECT 
		t.TReferenceId, SUM(fnr.Energy) s_Energy, SUM(fnr.Protein) s_Protein, SUM(fnr.carbohydrate) s_carbohydrate, SUM(fnr.Fat) s_Fat, SUM(fnr.Ash) s_Ash, SUM(fnr.Dietary_Fibre) s_Dietary_Fibre, SUM(fnr.Fructose) s_Fructose, SUM(fnr.Glucose) s_Glucose, SUM(fnr.Sucrose) s_Sucrose, SUM(fnr.Lactose) s_Lactose, SUM(fnr.Total_Sugars) s_Total_Sugars, SUM(fnr.Starch) s_Starch, SUM(fnr.Calcium) s_Calcium, SUM(fnr.Chloride) s_Chloride, SUM(fnr.Copper) s_Copper, SUM(fnr.Fluoride) s_Fluoride, SUM(fnr.Iodine) s_Iodine, SUM(fnr.Iron) s_Iron, SUM(fnr.Magnesium) s_Magnesium, SUM(fnr.Manganese) s_Manganese, SUM(fnr.Phosphorus) s_Phosphorus, SUM(fnr.Potassium) s_Potassium, SUM(fnr.Selenium) s_Selenium, SUM(fnr.Sodium) s_Sodium, SUM(fnr.Sulphur) s_Sulphur, SUM(fnr.Tin) s_Tin, SUM(fnr.Zinc) s_Zinc, SUM(fnr.Alpha_Carotene) s_Alpha_Carotene, SUM(fnr.Beta_Carotene) s_Beta_Carotene, SUM(fnr.Cryptoxanthin) s_Cryptoxanthin, SUM(fnr.Vitamin_A) s_Vitamin_A, SUM(fnr.Lutein) s_Lutein, SUM(fnr.Lycopene) s_Lycopene, SUM(fnr.Thiamin_B1) s_Thiamin_B1, SUM(fnr.Riboflavin_B2) s_Riboflavin_B2, SUM(fnr.Niacin_B3) s_Niacin_B3, SUM(fnr.Pantothenic_Acid_B5) s_Pantothenic_Acid_B5, SUM(fnr.Vitamin_B6) s_Vitamin_B6, SUM(fnr.Biotin_B7) s_Biotin_B7, SUM(fnr.Vitamin_B12) s_Vitamin_B12, SUM(fnr.Folate) s_Folate, SUM(fnr.Folic_Acid) s_Folic_Acid, SUM(fnr.Vitamin_C) s_Vitamin_C, SUM(fnr.Vitamin_D) s_Vitamin_D, SUM(fnr.Molybdenum) s_Molybdenum, SUM(fnr.Chromium) s_Chromium, SUM(fnr.Vitamin_E) s_Vitamin_E, SUM(fnr.Total_Saturated_Fatty_Acids) s_Total_Saturated_Fatty_Acids, SUM(fnr.Total_Monounsaturated_Fatty_Acids) s_Total_Monounsaturated_Fatty_Acids, SUM(fnr.Total_Polyunsaturated_Fatty_Acids) s_Total_Polyunsaturated_Fatty_Acids, SUM(fnr.Total_Long_Chain_Omega_3_Fatty_Acids) s_Total_Long_Chain_Omega_3_Fatty_Acids, SUM(fnr.Total_Trans_Fatty_Acids) s_Total_Trans_Fatty_Acids, SUM(fnr.Caffeine) s_Caffeine, SUM(fnr.Cholesterol) s_Cholesterol
		FROM TFood t WITH(NOLOCK)
		JOIN TFoodNutrition tn WITH(NOLOCK) ON t.id = tn.TFoodId 
		JOIN TReference fnr WITH(NOLOCK) ON fnr.id = tn.TReferenceId
		JOIN TReference fr WITH(NOLOCK) ON fr.id = t.TReferenceId
		WHERE t.Id = @FoodId
		GROUP BY t.Id, t.TReferenceId 
	) summary_result ON fr.Id = summary_result.TReferenceId
	WHERE t.Id = @FoodID
	
	UPDATE fr SET fr.Calorie = CAST(fr.Energy / 4.184 AS INT)
	FROM TFood f 
	JOIN TReference fr ON f.TReferenceId = fr.Id 
	WHERE f.id = @FoodID
END
GO 
UPDATE fr SET fr.Calorie = CAST(fr.Energy / 4.184 AS INT)
FROM TFood f 
JOIN TReference fr ON f.TReferenceId = fr.Id 
GO