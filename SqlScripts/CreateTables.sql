
-- CREATE TABLES

IF (EXISTS (SELECT Table_Catalog FROM Information_Schema.Tables WHERE Table_Schema = 'dbo' AND Table_Name = 'Laptops'))
BEGIN
    DROP TABLE dbo.Laptops
END

IF (EXISTS (SELECT Table_Catalog FROM Information_Schema.Tables WHERE Table_Schema = 'dbo' AND Table_Name = 'Users'))
BEGIN
    DROP TABLE dbo.Users
END

CREATE TABLE Users
(
    Id				INT IDENTITY(1, 1) NOT NULL,
    EmailAddress	NVARCHAR(255) UNIQUE NOT NULL,
    HashedPassword	VARCHAR(255) NOT NULL,
	CONSTRAINT PK__Users__3214EC07EA1A29D8 PRIMARY KEY (Id)
)

CREATE TABLE Laptops
(
	Id			INT IDENTITY(1, 1) NOT NULL,
	Brand		VARCHAR(50) NOT NULL,
	SerialNo	VARCHAR(255) NOT NULL,
	UserId		INT NOT NULL,
	CONSTRAINT PK__Laptops__3214EC079239A3F2 PRIMARY KEY (Id),
	CONSTRAINT FK__Laptops__UserId__4E88ABD4 FOREIGN KEY (UserId) REFERENCES Users (Id)
)

-- ADD EXAMPLE DATA

BEGIN TRY

    BEGIN TRANSACTION

    INSERT INTO Users 
        (EmailAddress, HashedPassword) 
    VALUES
        ('jonny@example.com','password1234'),
        ('bravo@example.com','admin2020')

    INSERT INTO Laptops 
        (Brand, SerialNo, UserId) 
    VALUES
        ('Lenovo', 'C02L456987', 1),
        ('Dell', '123AB458GH', 2),
        ('HP', 'PO54654PUXR', 2)

    COMMIT TRANSACTION

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	;THROW
END CATCH
