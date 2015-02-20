MERGE INTO Genre AS Target 
USING (VALUES 
        (1, 'Alternative'), 
        (2, 'Blues'), 
        (3, 'Classical')
) 
AS Source (GenreID, Name) 
ON Target.GenreID = Source.GenreID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Name) 
VALUES (Name);



MERGE INTO Artist AS Target
USING (VALUES 
        (1, 'Cat', 'From da alley', 3), 
        (2, 'Dog', 'From da mud', 2), 
		(3, 'Duck', 'From da pond', 1)
)
AS Source (Id, StageName, Description, GenreID)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (StageName, Description, GenreID)
VALUES (StageName, Description, GenreID);



MERGE INTO Host AS Target
USING (VALUES 
        (1, 'Megadome', 'Big', 'Baltimore, MD', '1234567890', 'http://www.google.com'), 
        (2, 'Superdome', 'Huge', 'Towson, MD', '1234567890', 'http://www.google.com'), 
		(3, 'Stadium', 'Open roof', 'Hunt Valley, MD', '1234567890', 'http://www.google.com')
)
AS Source (Id, VenueName, Description, Address, Phone, Website)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (VenueName, Description, Address, Phone, Website)
VALUES (VenueName, Description, Address, Phone, Website);



MERGE INTO Listener AS Target
USING (VALUES 
        (1, 'Joe', 'Montana', 'Baltimore', 'MD'), 
        (2, 'Susie', 'California', 'Towson', 'TX'), 
		(3, 'Calvin', 'Colorado', 'Hunt Valley', 'VA')
)
AS Source (Id, FirstName, LastName, City, State)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (FirstName, LastName, City, State)
VALUES (FirstName, LastName, City, State);