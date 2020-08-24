BEGIN TRAN

IF NOT EXISTS (SELECT 1 FROM  TActivityLevel)
BEGIN
    INSERT INTO TActivityLevel 
    (Title, Note, PALForMale, PALForFemale, Protein, Carb, Created, Enabled)
    VALUES 
    ('Sedentary', 'loreLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt utm', 1.3,1.3, 0.8, 3, GETDATE(), 1),
    ('Lightly Active', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do', 1.5,1.4, 1, 5, GETDATE(), 1),
    ('Moderately Active', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut ', 1.6,1.5, 1.2, 7, GETDATE(), 1),
    ('very Active', 'Lorem ipsum dolor sit amet, consectetur ', 1.8,1.7, 1.7, 10, GETDATE(), 1),
    ('Extremely Active / Athletic', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut Lorem ipsum dolor sit amet, consectetur adipiscing', 1.9,1.8, 1.9, 12, GETDATE(), 1)
END
--SELECT * FROM TActivityLevel

IF NOT EXISTS (SELECT 1 FROM  TGoal)
BEGIN
    SET IDENTITY_INSERT TGoal ON
    INSERT INTO TGoal 
    (id, Title, Created, Enabled)
    VALUES 
    (1, 'Lose Weigth', GETDATE(), 1),
    (2, 'Gain Weigth', GETDATE(), 1),
    (3, 'Maintain Weigth', GETDATE(), 1)
    SET IDENTITY_INSERT TGoal OFF
END
--SELECT * FROM TGoal

IF NOT EXISTS (SELECT 1 FROM  TWeeklyGoal)
BEGIN
    INSERT INTO TWeeklyGoal 
    (TGoalId, Title, Note, Created, Enabled)
    VALUES 
    (1, 'Lose 0.25 Kg per week', '', GETDATE(), 1),
    (1, 'Lose 0.5 Kg per week', '', GETDATE(), 1),
    (1, 'Lose 0.75 Kg per week', '', GETDATE(), 1),
    (1, 'Lose 1 Kg per week', '', GETDATE(), 1),
    (2, 'Gain 0.25 Kg per week', '', GETDATE(), 1),
    (2, 'Gain 0.5 Kg per week', '', GETDATE(), 1),
    (2, 'Gain 0.75 Kg per week', '', GETDATE(), 1),
    (2, 'Gain 1 Kg per week', '', GETDATE(), 1),
    (3, 'Maintain your current weight', '', GETDATE(), 1)
END
--SELECT * FROM TWeeklyGoal


IF NOT EXISTS (SELECT 1 FROM TSport)
BEGIN
    INSERT INTO TSport        
    (Title, [Image], Created, Enabled)
    VALUES
        ('Football', '/img/sports/football.svg', GETDATE(), 1),
        ('Golf', '/img/sports/golf.svg', GETDATE(), 1),
        ('Cricket', '/img/sports/cricket.svg', GETDATE(), 1),
        ('Tennis', '/img/sports/tennis.svg', GETDATE(), 1),
        ('Squash', '/img/sports/squash.svg', GETDATE(), 1),
        ('Soccer', '/img/sports/soccer.svg', GETDATE(), 1),
        ('Basketball', '/img/sports/basketball.svg', GETDATE(), 1),
        ('Netball', '/img/sports/netball.svg', GETDATE(), 1),
        ('Gym', '/img/sports/gym.svg', GETDATE(), 1),
        ('Running', '/img/sports/running.svg', GETDATE(), 1),
        ('Cycling', '/img/sports/cycling.svg', GETDATE(), 1),
        ('Surfing', '/img/sports/surfing.svg', GETDATE(), 1),
        ('Swimming', '/img/sports/swimming.svg', GETDATE(), 1),
        ('Martial art', '/img/sports/martial-art.svg', GETDATE(), 1),
        ('Dancing', '/img/sports/dancing.svg', GETDATE(), 1),
        ('Yoga', '/img/sports/yoga.svg', GETDATE(), 1)
END
--SELECT * FROM TSport

IF NOT EXISTS (SELECT 1 FROM  TBodyType)
BEGIN
    INSERT INTO TBodyType 
    (Title, [Image], Created, Enabled)
    VALUES 
    ('pear',        '/img/body-types/pear.svg', GETDATE(), 1),
    ('rectangle',   '/img/body-types/rectangle.svg', GETDATE(), 1),
    ('hourglass',   '/img/body-types/hourglass.svg', GETDATE(), 1),
    ('strawberry',  '/img/body-types/strawberry.svg', GETDATE(), 1),
    ('apple',       '/img/body-types/apple.svg', GETDATE(), 1)
END
--SELECT * FROM TBodyType

IF NOT EXISTS (SELECT 1 FROM  TFoodType)
BEGIN
    INSERT INTO TFoodType 
    (Title, [Image], Created, Enabled)
    VALUES 
    ('Asian',           '/img/food-types/asian.svg', GETDATE(), 1),
    ('Mexican',         '/img/food-types/mexican.svg', GETDATE(), 1),
    ('Chinese',         '/img/food-types/chinese.svg', GETDATE(), 1),
    ('Mediteranian',    '/img/food-types/mediteranian.svg', GETDATE(), 1),
    ('Greek',           '/img/food-types/greek.svg', GETDATE(), 1),
    ('Italian',         '/img/food-types/italian.svg', GETDATE(), 1),
    ('Spanish',         '/img/food-types/spanish.svg', GETDATE(), 1),
    ('Indian',          '/img/food-types/indian.svg', GETDATE(), 1),
    ('Thai',            '/img/food-types/thai.svg', GETDATE(), 1)
END
--SELECT * FROM TFoodType

IF NOT EXISTS (SELECT 1 FROM  TAllergy)
BEGIN
    INSERT INTO TAllergy
    (Title, Created, Enabled)
    VALUES 
        ('Milk(lactose intolerance)', GETDATE(), 1),
        ('Eggs', GETDATE(), 1),
        ('Tree Nuts', GETDATE(), 1),
        ('Peanuts', GETDATE(), 1),
        ('Shellfish', GETDATE(), 1),
        ('Wheat gluten', GETDATE(), 1),
        ('Soy', GETDATE(), 1),
        ('Fish', GETDATE(), 1),
        ('Milk', GETDATE(), 1),
        ('Milk powder', GETDATE(), 1),
        ('Cheese', GETDATE(), 1),
        ('Butter', GETDATE(), 1),
        ('Margarine', GETDATE(), 1),
        ('Yogurt', GETDATE(), 1),
        ('Cream', GETDATE(), 1),
        ('Ice cream	', GETDATE(), 1),
        ('Brazil nuts', GETDATE(), 1),
        ('Almonds', GETDATE(), 1),
        ('Cashews', GETDATE(), 1),
        ('Macadamia nuts', GETDATE(), 1),
        ('Pistachios', GETDATE(), 1),
        ('Pine nuts', GETDATE(), 1),
        ('Walnuts', GETDATE(), 1),
        ('Shrimp', GETDATE(), 1),
        ('Prawns', GETDATE(), 1),
        ('Crayfish', GETDATE(), 1),
        ('Lobster', GETDATE(), 1),
        ('Squid', GETDATE(), 1),
        ('Scallops', GETDATE(), 1),
        ('Linseed', GETDATE(), 1),
        ('Sesame seed', GETDATE(), 1),
        ('Peach', GETDATE(), 1),
        ('Banana', GETDATE(), 1),
        ('Avocado', GETDATE(), 1),
        ('Kiwi fruit', GETDATE(), 1),
        ('Passion fruit', GETDATE(), 1),
        ('Celery', GETDATE(), 1),
        ('Garlic', GETDATE(), 1),
        ('Mustard seeds', GETDATE(), 1),
        ('Aniseed', GETDATE(), 1),
        ('Chamomil', GETDATE(), 1)
END
--SELECT * FROM TAllergy


IF NOT EXISTS (SELECT 1 FROM  TDiet)
BEGIN
    INSERT INTO TDiet 
    (Title, [Image], Created, Enabled)
    VALUES 
        ('Vegetarian', '', GETDATE(), 1),
        ('Vegan', '', GETDATE(), 1),
        ('Ketogenic', '', GETDATE(), 1),
        ('Halal only', '', GETDATE(), 1)
END
--SELECT * FROM TDiet

IF NOT EXISTS (SELECT 1 FROM  TDeficiency)
BEGIN
    INSERT INTO TDeficiency 
    (Title, [Image], Created, Enabled)
    VALUES 
        ('Calcium (mg)', '', GETDATE(), 1),
        ('Iron (mg)', '', GETDATE(), 1),
        ('Magnesium (mg)', '', GETDATE(), 1),
        ('Phosphorus (mg)', '', GETDATE(), 1),
        ('Potasssium (mg)', '', GETDATE(), 1),
        ('Sodium (mg)', '', GETDATE(), 1),
        ('Zinc (mg)', '', GETDATE(), 1),
        ('Cupper (mg)', '', GETDATE(), 1),
        ('Manganese (mg)', '', GETDATE(), 1),
        ('Selenium (mcg)', '', GETDATE(), 1),
        ('Vitamin A (IU)', '', GETDATE(), 1),
        ('Retinol (mcg)', '', GETDATE(), 1),
        ('Beta Carotene (mcg)', '', GETDATE(), 1),
        ('Alpha Carotene (mcg)', '', GETDATE(), 1),
        ('Vitamin E (mg)', '', GETDATE(), 1),
        ('Vitamin D (mcg)', '', GETDATE(), 1),
        ('Vitamin D2 (Ergocalciferol)  (mcg)', '', GETDATE(), 1),
        ('Vitamin D3 (Cholecalciferol) (mcg)', '', GETDATE(), 1),
        ('Beta Cryptoxanthin (mcg)', '', GETDATE(), 1),
        ('Lycopene (mcg)', '', GETDATE(), 1),
        ('Lutein and Zeaxanthin (mcg)', '', GETDATE(), 1),
        ('Vitamin C (mg)', '', GETDATE(), 1),
        ('Thiamin (B1) (mg)', '', GETDATE(), 1),
        ('Riboflavin (B2) (mg)', '', GETDATE(), 1),
        ('Niacin (B3) (mg)', '', GETDATE(), 1),
        ('Vitamin B5 (mg)', '', GETDATE(), 1),
        ('Vitamin B6 (mg)', '', GETDATE(), 1),
        ('Folate (B9) (mg)', '', GETDATE(), 1),
        ('Vitamin B12', '', GETDATE(), 1),
        ('Choline (mg)', '', GETDATE(), 1)
END
--SELECT * FROM TDeficiency



IF NOT EXISTS (SELECT 1 FROM  TNutritionCondition)
BEGIN
    INSERT INTO TNutritionCondition 
    (Title, [Image], Created, Enabled)
    VALUES 
        ('High blood presure (HBP) - Hypertension', '', GETDATE(), 1),
        ('Type 2 diabetes', '', GETDATE(), 1),
        ('high cholesterol - low-density lipoprotein (LDL)', '', GETDATE(), 1),
        ('Obesity', '', GETDATE(), 1),
        ('Constipation', '', GETDATE(), 1)
END
--SELECT * FROM TNutritionCondition



ROLLBACK
--COMMIT