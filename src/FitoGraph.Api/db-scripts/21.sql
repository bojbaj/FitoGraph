IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spFindBestFoodsForCustomer')
	DROP PROCEDURE spFindBestFoodsForCustomer
GO
CREATE PROCEDURE spFindBestFoodsForCustomer(@UserID INT) AS
BEGIN
	DECLARE @Age INT
	SELECT @Age = DATEPART(YEAR, GETDATE()) - BirthYear FROM TUser u WHERE u.id = @UserID	
	
	SELECT f.* 
	FROM TFood f
	JOIN TReference food_r ON food_r.id = f.TReferenceId 
	ORDER BY f.Created DESC
	
--	SELECT * FROM (
--		SELECT u.id UserID, @Age userAge, 
--		rr.FromAge, rr.ToAge, rr.Gender,	
--		r.Energy * rG.Energy Energy,
--		r.Protein * rG.Protein Protein,
--		r.carbohydrate * rG.carbohydrate carbohydrate,
--		r.Fat * rG.Fat Fat,
--		r.Ash * rG.Ash Ash,
--		r.Dietary_Fibre * rG.Dietary_Fibre Dietary_Fibre,
--		r.Fructose * rG.Fructose Fructose,
--		r.Glucose * rG.Glucose Glucose,
--		r.Sucrose * rG.Sucrose Sucrose,
--		r.Lactose * rG.Lactose Lactose,
--		r.Total_Sugars * rG.Total_Sugars Total_Sugars,
--		r.Starch * rG.Starch Starch,
--		r.Calcium * rG.Calcium Calcium,
--		r.Chloride * rG.Chloride Chloride,
--		r.Copper * rG.Copper Copper,
--		r.Fluoride * rG.Fluoride Fluoride,
--		r.Iodine * rG.Iodine Iodine,
--		r.Iron * rG.Iron Iron,
--		r.Magnesium * rG.Magnesium Magnesium,
--		r.Manganese * rG.Manganese Manganese,
--		r.Phosphorus * rG.Phosphorus Phosphorus,
--		r.Potassium * rG.Potassium Potassium,
--		r.Selenium * rG.Selenium Selenium,
--		r.Sodium * rG.Sodium Sodium,
--		r.Sulphur * rG.Sulphur Sulphur,
--		r.Tin * rG.Tin Tin,
--		r.Zinc * rG.Zinc Zinc,
--		r.Alpha_Carotene * rG.Alpha_Carotene Alpha_Carotene,
--		r.Beta_Carotene * rG.Beta_Carotene Beta_Carotene,
--		r.Cryptoxanthin * rG.Cryptoxanthin Cryptoxanthin,
--		r.Vitamin_A * rG.Vitamin_A Vitamin_A,
--		r.Lutein * rG.Lutein Lutein,
--		r.Lycopene * rG.Lycopene Lycopene,
--		r.Thiamin_B1 * rG.Thiamin_B1 Thiamin_B1,
--		r.Riboflavin_B2 * rG.Riboflavin_B2 Riboflavin_B2,
--		r.Niacin_B3 * rG.Niacin_B3 Niacin_B3,
--		r.Pantothenic_Acid_B5 * rG.Pantothenic_Acid_B5 Pantothenic_Acid_B5,
--		r.Vitamin_B6 * rG.Vitamin_B6 Vitamin_B6,
--		r.Biotin_B7 * rG.Biotin_B7 Biotin_B7,
--		r.Vitamin_B12 * rG.Vitamin_B12 Vitamin_B12,
--		r.Folate * rG.Folate Folate,
--		r.Folic_Acid * rG.Folic_Acid Folic_Acid,
--		r.Vitamin_C * rG.Vitamin_C Vitamin_C,
--		r.Vitamin_D * rG.Vitamin_D Vitamin_D,
--		r.Molybdenum * rG.Molybdenum Molybdenum,
--		r.Chromium * rG.Chromium Chromium,
--		r.Vitamin_E * rG.Vitamin_E Vitamin_E,
--		r.Total_Saturated_Fatty_Acids * rG.Total_Saturated_Fatty_Acids Total_Saturated_Fatty_Acids,
--		r.Total_Monounsaturated_Fatty_Acids * rG.Total_Monounsaturated_Fatty_Acids Total_Monounsaturated_Fatty_Acids,
--		r.Total_Polyunsaturated_Fatty_Acids * rG.Total_Polyunsaturated_Fatty_Acids Total_Polyunsaturated_Fatty_Acids,
--		r.Total_Long_Chain_Omega_3_Fatty_Acids * rG.Total_Long_Chain_Omega_3_Fatty_Acids Total_Long_Chain_Omega_3_Fatty_Acids,
--		r.Total_Trans_Fatty_Acids * rG.Total_Trans_Fatty_Acids Total_Trans_Fatty_Acids,
--		r.Caffeine * rG.Caffeine Caffeine,
--		r.Cholesterol * rG.Cholesterol Cholesterol
--		FROM TUser u
--		JOIN TReferenceInRange rr 
--			ON rr.Gender = u.Gender AND rr.FromAge <= @Age AND rr.ToAge >= @Age 
--		JOIN TReference r ON r.id = rr.TReferenceId 
--		JOIN TReference rG ON rG.id = u.TReferenceId 
--		WHERE u.id = @UserID
--	) userReference
	

 	

	
--
--	IF NOT EXISTS (SELECT 1 FROM #user_need)
--	BEGIN
--		--Exception
--		RETURN
--	END


END
GO
EXEC spFindBestFoodsForCustomer 1