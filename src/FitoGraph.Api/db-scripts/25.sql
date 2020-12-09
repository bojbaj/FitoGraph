IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'spFindBestFoodsForCustomer')
	DROP PROCEDURE spFindBestFoodsForCustomer
GO
CREATE PROCEDURE spFindBestFoodsForCustomer(@UserID INT) AS
BEGIN
	DECLARE @Age INT
	SELECT @Age = DATEPART(YEAR, GETDATE()) - BirthYear FROM TUser u WHERE u.id = @UserID	
	
	SELECT f.Id, f.Title, f.Image, f.Tags, f.Price, food_r.Fat, food_r.Protein, food_r.carbohydrate Carb,
	(f.Id % 4) MatchRate,
	restaurant.RestaurantName 'Restaurant'
	FROM TFood f
	JOIN TReference food_r ON food_r.id = f.TReferenceId
	JOIN TUser restaurant ON restaurant.id = f.TUserId 
	ORDER BY f.Created DESC
END
GO
EXEC spFindBestFoodsForCustomer 1

SELECT * FROM TFood t 