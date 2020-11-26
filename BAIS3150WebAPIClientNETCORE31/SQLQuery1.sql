DROP TABLE Item
Drop Table ItemDetail
--
CREATE TABLE Item 
(
	ItemNumber INT IDENTITY(1,1) NOT NULL,
	Description VARCHAR(50) NOT NULL,
	UnitPrice MONEY NOT NULL
)

ALTER TABLE Item
	ADD CONSTRAINT PK_Item PRIMARY KEY (ItemNumber)


--
go
CREATE PROCEDURE AddItem(@Description VARCHAR(50) = NULL, @UnitPrice MONEY = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1
	IF @Description IS NULL
		RAISERROR('Description Can not be NULL', 16,1)
	ELSE
		IF @UnitPrice IS NULL
			RAISERROR('UnitPrice Can not be NULL', 16,1)
		ELSE
			BEGIN
				INSERT INTO Item
						(Description, UnitPrice )
				VALUES  (@Description, @UnitPrice)
		
				IF @@ERROR = 0
					SET @ReturnCode = 0
				ELSE
					RAISERROR('An unkown error has occured, Please try again.',16,1)
			END
		RETURN @ReturnCode

EXEC AddItem 'ExampleItem1', 9.99
EXEC AddItem 'ExampleItemToBeDeleted', 7.99
EXEC AddItem 'ExampleItem3', 8.99
EXEC AddItem 'ExampleItem4', 6.69
EXEC AddItem 'ExampleItem5', 4.99


--
go
CREATE PROCEDURE UpdateItem(@ItemNumber INT = NULL, @Description VARCHAR(50) = NULL, @UnitPrice MONEY  = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @ItemNumber IS NULL
		RAISERROR('You need to provide an Item number for this to work ya silly goose',16,1)
	ELSE
		IF @Description IS NULL
			RAISERROR('Description Can not be NULL', 16,1)
		ELSE
			IF @UnitPrice IS NULL
				RAISERROR('UnitPrice Can not be NULL', 16,1)
			ELSE
				BEGIN
					UPDATE Item
					SET Description = @Description, UnitPrice = @UnitPrice
					WHERE ItemNumber = @ItemNumber

					IF @@ERROR = 0
						SET @ReturnCode = 0
					ELSE 
						RAISERROR('An unkown error has occured, Please try again.',16,1)
				END
			RETURN @ReturnCode

exec UpdateItem 1, 'UpdatedExample1', 10.00


--
go
CREATE PROCEDURE DeleteItem(@ItemNumber INT = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @ItemNumber IS NULL
		RAISERROR('You need to provide an Item number for this to work ya silly goose',16,1)
	ELSE
		BEGIN
			DELETE FROM Item 
			WHERE ItemNumber = @ItemNumber

			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('An unkown error has occured, Please try again.',16,1)
		END
	RETURN @ReturnCode

exec DeleteItem 2


--
go
CREATE PROCEDURE GetItem(@ItemNumber INT = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @ItemNumber IS NULL
		RAISERROR('You need to provide an Item number for this to work ya silly goose',16,1)
	ELSE
		BEGIN
			SELECT ItemNumber, Description, Unitprice
			FROM Item
			WHERE @ItemNumber = ItemNumber
				IF @@ERROR = 0
					SET @ReturnCode = 0
				ELSE
					RAISERROR('An unkown error has occured, Please try again.',16,1)
		END
		RETURN @ReturnCode

exec GetItem 1


--
go
CREATE PROCEDURE GetItems
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	SELECT ItemNumber, Description, UnitPrice
	FROM Item

	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE 
		RAISERROR('An unkown error has occured, Please try again.',16,1)

	RETURN @ReturnCode

exec GetItems


