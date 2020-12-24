IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'fReturnMatchRate')
	DROP FUNCTION fReturnMatchRate
GO
CREATE FUNCTION fReturnMatchRate (@Diff INT, @dietMatch TINYINT, @deficiencyMatch TINYINT, @nutritionConditionMatch TINYINT) RETURNS INT AS 
BEGIN
		
	IF @dietMatch = 1 OR @deficiencyMatch = 1 OR @nutritionConditionMatch = 1
		RETURN 4	
	
	IF @Diff BETWEEN -200 AND 200
		RETURN 4
	
	IF @Diff BETWEEN -400 AND 400
		RETURN 3

	IF @Diff BETWEEN -600 AND 600
		RETURN 2

	IF @Diff BETWEEN -800 AND 800
		RETURN 1

	IF @Diff BETWEEN -1000 AND 1000
		RETURN 0

	RETURN 0
END 
GO
IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spFindBestFoodsForCustomer')
	DROP PROCEDURE spFindBestFoodsForCustomer
GO
CREATE PROCEDURE spFindBestFoodsForCustomer(@UserID INT, @Calorie INT) AS
BEGIN
	DECLARE @GFactorId INT = 0	
	DECLARE @Age INT
	SELECT @Age = DATEPART(YEAR, GETDATE()) - BirthYear FROM TUser u WHERE u.id = @UserID	
		
		
	
	SELECT @GFactorId = u.TReferenceId FROM TUser u WHERE u.id = @UserID
	
	SELECT fd.TFoodId into #tmp_diets FROM TFoodDiet fd WHERE fd.TDietId IN 
		(SELECT ud.TDietId FROM TUserDiet ud  WHERE ud.TUserId  = @UserID)

	SELECT fd.TFoodId into #tmp_deficiencies FROM TFoodDeficiency fd WHERE fd.TDeficiencyId IN 
		(SELECT ud.TDeficiencyId FROM TUserDeficiency ud WHERE ud.TUserId  = @UserID)

	SELECT fnc.TFoodId into #tmp_nutrition_conditions FROM TFoodNutritionCondition fnc WHERE fnc.TNutritionConditionId IN 
		(SELECT unc.TNutritionConditionId FROM TUserNutritionCondition unc WHERE unc.TUserId  = @UserID)
				
	SELECT fa.TFoodId into #tmp_allergies FROM TFoodAllergy fa WHERE fa.TAllergyId IN 
		(SELECT ua.TAllergyId FROM TUserAllergy ua WHERE ua.TUserId  = @UserID)		
		
	SELECT 	
	f.Id, f.Title, f.Image, f.Tags, f.Price, food_r.Fat, food_r.Protein, food_r.carbohydrate Carb,
	restaurant.RestaurantName 'Restaurant',
	(food_r.Calorie - @Calorie) CalorieDiff, food_r.Calorie,	
	CASE WHEN EXISTS (SELECT 1 FROM #tmp_allergies WHERE TFoodId = f.id) THEN 1 ELSE 0 END AllergyMatched,
	CASE WHEN EXISTS (SELECT 1 FROM #tmp_diets WHERE TFoodId = f.id) THEN 1 ELSE 0 END DietMatched,
	CASE WHEN EXISTS (SELECT 1 FROM #tmp_deficiencies WHERE TFoodId = f.id) THEN 1 ELSE 0 END DeficiencyMatched,
	CASE WHEN EXISTS (SELECT 1 FROM #tmp_nutrition_conditions WHERE TFoodId = f.id) THEN 1 ELSE 0 END NutritionConditionMatched,
	dbo.fReturnMatchRate(
	(food_r.Calorie - @Calorie), 
	CASE WHEN EXISTS (SELECT 1 FROM #tmp_diets WHERE TFoodId = f.id) THEN 1 ELSE 0 END,
	CASE WHEN EXISTS (SELECT 1 FROM #tmp_deficiencies WHERE TFoodId = f.id) THEN 1 ELSE 0 END, 
	CASE WHEN EXISTS (SELECT 1 FROM #tmp_nutrition_conditions WHERE TFoodId = f.id) THEN 1 ELSE 0 END
	) MatchRate,
	(
		(food_r.Energy * g_factor.Energy) +
		(food_r.Protein * g_factor.Protein) +
		(food_r.carbohydrate * g_factor.carbohydrate) +
		(food_r.Fat * g_factor.Fat) +
		(food_r.Ash * g_factor.Ash) +
		(food_r.Dietary_Fibre * g_factor.Dietary_Fibre) +
		(food_r.Fructose * g_factor.Fructose) +
		(food_r.Glucose * g_factor.Glucose) +
		(food_r.Sucrose * g_factor.Sucrose) +
		(food_r.Lactose * g_factor.Lactose) +
		(food_r.Total_Sugars * g_factor.Total_Sugars) +
		(food_r.Starch * g_factor.Starch) +
		(food_r.Calcium * g_factor.Calcium) +
		(food_r.Chloride * g_factor.Chloride) +
		(food_r.Copper * g_factor.Copper) +
		(food_r.Fluoride * g_factor.Fluoride) +
		(food_r.Iodine * g_factor.Iodine) +
		(food_r.Iron * g_factor.Iron) +
		(food_r.Magnesium * g_factor.Magnesium) +
		(food_r.Manganese * g_factor.Manganese) +
		(food_r.Phosphorus * g_factor.Phosphorus) +
		(food_r.Potassium * g_factor.Potassium) +
		(food_r.Selenium * g_factor.Selenium) +
		(food_r.Sodium * g_factor.Sodium) +
		(food_r.Sulphur * g_factor.Sulphur) +
		(food_r.Tin * g_factor.Tin) +
		(food_r.Zinc * g_factor.Zinc) +
		(food_r.Alpha_Carotene * g_factor.Alpha_Carotene) +
		(food_r.Beta_Carotene * g_factor.Beta_Carotene) +
		(food_r.Cryptoxanthin * g_factor.Cryptoxanthin) +
		(food_r.Vitamin_A * g_factor.Vitamin_A) +
		(food_r.Lutein * g_factor.Lutein) +
		(food_r.Lycopene * g_factor.Lycopene) +
		(food_r.Thiamin_B1 * g_factor.Thiamin_B1) +
		(food_r.Riboflavin_B2 * g_factor.Riboflavin_B2) +
		(food_r.Niacin_B3 * g_factor.Niacin_B3) +
		(food_r.Pantothenic_Acid_B5 * g_factor.Pantothenic_Acid_B5) +
		(food_r.Vitamin_B6 * g_factor.Vitamin_B6) +
		(food_r.Biotin_B7 * g_factor.Biotin_B7) +
		(food_r.Vitamin_B12 * g_factor.Vitamin_B12) +
		(food_r.Folate * g_factor.Folate) +
		(food_r.Folic_Acid * g_factor.Folic_Acid) +
		(food_r.Vitamin_C * g_factor.Vitamin_C) +
		(food_r.Vitamin_D * g_factor.Vitamin_D) +
		(food_r.Molybdenum * g_factor.Molybdenum) +
		(food_r.Chromium * g_factor.Chromium) +
		(food_r.Vitamin_E * g_factor.Vitamin_E) +
		(food_r.Total_Saturated_Fatty_Acids * g_factor.Total_Saturated_Fatty_Acids) +
		(food_r.Total_Monounsaturated_Fatty_Acids * g_factor.Total_Monounsaturated_Fatty_Acids) +
		(food_r.Total_Polyunsaturated_Fatty_Acids * g_factor.Total_Polyunsaturated_Fatty_Acids) +
		(food_r.Total_Long_Chain_Omega_3_Fatty_Acids * g_factor.Total_Long_Chain_Omega_3_Fatty_Acids) +
		(food_r.Total_Trans_Fatty_Acids * g_factor.Total_Trans_Fatty_Acids) +
		(food_r.Caffeine * g_factor.Caffeine) +
		(food_r.Cholesterol * g_factor.Cholesterol)	
	) 
	TotalGFactor
	into #tmp_food_list
	FROM TFood f
	JOIN TReference food_r ON food_r.id = f.TReferenceId
	JOIN TUser restaurant ON restaurant.id = f.TUserId	
	JOIN TReference g_factor ON g_factor.id = @GFactorID
	WHERE f.Enabled = 1 --AND f.Price > 0
	
	SELECT *	
	FROM #tmp_food_list t	
	ORDER BY 
	t.MatchRate DESC,
	t.TotalGFactor DESC,
	ABS(t.CalorieDiff) ASC
	
END
GO
EXEC spFindBestFoodsForCustomer 1, 500
