IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'fReturnMatchRate')
	DROP FUNCTION fReturnMatchRate
GO
CREATE FUNCTION fReturnMatchRate (@Diff INT, @dietMatch TINYINT, @deficiencyMatch TINYINT, @nutritionConditionMatch TINYINT) RETURNS INT AS 
BEGIN
		
	-- IF @dietMatch = 1 OR @deficiencyMatch = 1 OR @nutritionConditionMatch = 1
	-- 	RETURN 4	
	
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
		(food_r.Energy * ISNULL(g_factor.Energy, 1)) +
		(food_r.Protein * ISNULL(g_factor.Protein, 1)) +
		(food_r.carbohydrate * ISNULL(g_factor.carbohydrate, 1)) +
		(food_r.Fat * ISNULL(g_factor.Fat, 1)) +
		(food_r.Ash * ISNULL(g_factor.Ash, 1)) +
		(food_r.Dietary_Fibre * ISNULL(g_factor.Dietary_Fibre, 1)) +
		(food_r.Fructose * ISNULL(g_factor.Fructose, 1)) +
		(food_r.Glucose * ISNULL(g_factor.Glucose, 1)) +
		(food_r.Sucrose * ISNULL(g_factor.Sucrose, 1)) +
		(food_r.Lactose * ISNULL(g_factor.Lactose, 1)) +
		(food_r.Total_Sugars * ISNULL(g_factor.Total_Sugars, 1)) +
		(food_r.Starch * ISNULL(g_factor.Starch, 1)) +
		(food_r.Calcium * ISNULL(g_factor.Calcium, 1)) +
		(food_r.Chloride * ISNULL(g_factor.Chloride, 1)) +
		(food_r.Copper * ISNULL(g_factor.Copper, 1)) +
		(food_r.Fluoride * ISNULL(g_factor.Fluoride, 1)) +
		(food_r.Iodine * ISNULL(g_factor.Iodine, 1)) +
		(food_r.Iron * ISNULL(g_factor.Iron, 1)) +
		(food_r.Magnesium * ISNULL(g_factor.Magnesium, 1)) +
		(food_r.Manganese * ISNULL(g_factor.Manganese, 1)) +
		(food_r.Phosphorus * ISNULL(g_factor.Phosphorus, 1)) +
		(food_r.Potassium * ISNULL(g_factor.Potassium, 1)) +
		(food_r.Selenium * ISNULL(g_factor.Selenium, 1)) +
		(food_r.Sodium * ISNULL(g_factor.Sodium, 1)) +
		(food_r.Sulphur * ISNULL(g_factor.Sulphur, 1)) +
		(food_r.Tin * ISNULL(g_factor.Tin, 1)) +
		(food_r.Zinc * ISNULL(g_factor.Zinc, 1)) +
		(food_r.Alpha_Carotene * ISNULL(g_factor.Alpha_Carotene, 1)) +
		(food_r.Beta_Carotene * ISNULL(g_factor.Beta_Carotene, 1)) +
		(food_r.Cryptoxanthin * ISNULL(g_factor.Cryptoxanthin, 1)) +
		(food_r.Vitamin_A * ISNULL(g_factor.Vitamin_A, 1)) +
		(food_r.Lutein * ISNULL(g_factor.Lutein, 1)) +
		(food_r.Lycopene * ISNULL(g_factor.Lycopene, 1)) +
		(food_r.Thiamin_B1 * ISNULL(g_factor.Thiamin_B1, 1)) +
		(food_r.Riboflavin_B2 * ISNULL(g_factor.Riboflavin_B2, 1)) +
		(food_r.Niacin_B3 * ISNULL(g_factor.Niacin_B3, 1)) +
		(food_r.Pantothenic_Acid_B5 * ISNULL(g_factor.Pantothenic_Acid_B5, 1)) +
		(food_r.Vitamin_B6 * ISNULL(g_factor.Vitamin_B6, 1)) +
		(food_r.Biotin_B7 * ISNULL(g_factor.Biotin_B7, 1)) +
		(food_r.Vitamin_B12 * ISNULL(g_factor.Vitamin_B12, 1)) +
		(food_r.Folate * ISNULL(g_factor.Folate, 1)) +
		(food_r.Folic_Acid * ISNULL(g_factor.Folic_Acid, 1)) +
		(food_r.Vitamin_C * ISNULL(g_factor.Vitamin_C, 1)) +
		(food_r.Vitamin_D * ISNULL(g_factor.Vitamin_D, 1)) +
		(food_r.Molybdenum * ISNULL(g_factor.Molybdenum, 1)) +
		(food_r.Chromium * ISNULL(g_factor.Chromium, 1)) +
		(food_r.Vitamin_E * ISNULL(g_factor.Vitamin_E, 1)) +
		(food_r.Total_Saturated_Fatty_Acids * ISNULL(g_factor.Total_Saturated_Fatty_Acids, 1)) +
		(food_r.Total_Monounsaturated_Fatty_Acids * ISNULL(g_factor.Total_Monounsaturated_Fatty_Acids, 1)) +
		(food_r.Total_Polyunsaturated_Fatty_Acids * ISNULL(g_factor.Total_Polyunsaturated_Fatty_Acids, 1)) +
		(food_r.Total_Long_Chain_Omega_3_Fatty_Acids * ISNULL(g_factor.Total_Long_Chain_Omega_3_Fatty_Acids, 1)) +
		(food_r.Total_Trans_Fatty_Acids * ISNULL(g_factor.Total_Trans_Fatty_Acids, 1)) +
		(food_r.Caffeine * ISNULL(g_factor.Caffeine, 1)) +
		(food_r.Cholesterol * ISNULL(g_factor.Cholesterol, 1))
	) 
	TotalGFactor
	into #tmp_food_list
	FROM TFood f
	JOIN TReference food_r ON food_r.id = f.TReferenceId
	JOIN TUser restaurant ON restaurant.id = f.TUserId	
	LEFT JOIN TReference g_factor ON g_factor.id = @GFactorID
	WHERE f.Enabled = 1 --AND f.Price > 0
	
	SELECT *	
	FROM #tmp_food_list t	
	ORDER BY 
	t.MatchRate DESC,
	ABS(t.CalorieDiff) ASC,
	t.TotalGFactor DESC	
END
GO
EXEC spFindBestFoodsForCustomer 30, 886
