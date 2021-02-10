drop Table if exists SaleFact
drop Table if exists ShipperDimension
drop Table if exists EmployeeDimension
drop Table if exists ProductDimension
drop Table if exists CustomerDimension
drop Table if exists TimeDimension

ALTER TABLE SaleFact
DROP CONSTRAINT FK_SaleFact_CustomerDimension;
ALTER TABLE SaleFact
DROP CONSTRAINT FK_SaleFact_EmployeeDimension;
ALTER TABLE SaleFact
DROP CONSTRAINT FK_SaleFact_ProductDimension;
ALTER TABLE SaleFact
DROP CONSTRAINT FK_SaleFact_ShipperDimension;
ALTER TABLE SaleFact
DROP CONSTRAINT FK_SaleFact_TimeDimension;

TRUNCATE TABLE ShipperDimension
TRUNCATE TABLE EmployeeDimension
TRUNCATE TABLE ProductDimension
TRUNCATE TABLE CustomerDimension
TRUNCATE TABLE TimeDimension

ALTER TABLE SaleFact
ADD CONSTRAINT FK_SaleFact_CustomerDimension FOREIGN KEY (CustomerKey)
REFERENCES CustomerDimension(CustomerKey),
CONSTRAINT FK_SaleFact_EmployeeDimension FOREIGN KEY (EmployeeKey)
REFERENCES EmployeeDimension(EmployeeKey),
CONSTRAINT FK_SaleFact_ProductDimension FOREIGN KEY (ProductKey)
REFERENCES ProductDimension(ProductKey),
CONSTRAINT FK_SaleFact_ShipperDimension FOREIGN KEY (ShipperKey)
REFERENCES ShipperDimension(ShipperKey),
CONSTRAINT FK_SaleFact_TimeDimension FOREIGN KEY (TimeKey)
REFERENCES TimeDimension(TimeKey)
CREATE NONCLUSTERED INDEX IX_SaleFact_CustomerDimension
 ON SaleFact (CustomerKey);
CREATE NONCLUSTERED INDEX IX_SaleFact_EmployeeDimension
 ON SaleFact (EmployeeKey);
CREATE NONCLUSTERED INDEX IX_SaleFact_ProductDimension
 ON SaleFact (ProductKey);
CREATE NONCLUSTERED INDEX IX_SaleFact_ShipperDimension
 ON SaleFact (ShipperKey);
CREATE NONCLUSTERED INDEX IX_SaleFact_TimeDimension
 ON SaleFact (TimeKey);


CREATE TABLE dbo.SaleFact(
CustomerKey int NOT NULL,
EmployeeKey int NOT NULL,
ProductKey int NOT NULL,
ShipperKey int NOT NULL,
TimeKey int NOT NULL,
LineItemQuantity int NOT NULL,
LineItemDiscount money NOT NULL,
LineItemFreight money NOT NULL,
LineItemTotal money NOT NULL,

CONSTRAINT PK_SaleFact PRIMARY KEY NONCLUSTERED
(
CustomerKey ASC,
EmployeeKey ASC,
ProductKey ASC,
ShipperKey ASC,
TimeKey ASC
))



CREATE TABLE dbo.CustomerDimension(
CustomerKey int IDENTITY(1,1) NOT NULL,
CompanyName nvarchar(40) NOT NULL,
CustomerID nvarchar(5) NOT NULL,
ContactName nvarchar(30) NULL,
ContactTitle nvarchar(30) NULL,
Region nvarchar(50) NULL,
Address nvarchar(60) NULL,
City nvarchar(15) NULL,
PostalCode nvarchar(10) NULL,
Phone nvarchar(24) NULL,
Country nvarchar(15) NULL,
Fax nvarchar(24) NULL,

CONSTRAINT PK_CustomerDimension PRIMARY KEY NONCLUSTERED
(
CustomerKey ASC
))

CREATE TABLE dbo.EmployeeDimension(
EmployeeKey int IDENTITY(1,1) NOT NULL,
EmployeeName nvarchar(32) NOT NULL,
EmployeeID int NOT NULL,
HireDate datetime NOT NULL,

CONSTRAINT PK_EmployeeDimension PRIMARY KEY NONCLUSTERED
(
EmployeeKey ASC
))

CREATE TABLE dbo.ProductDimension(
ProductKey int IDENTITY(1,1) NOT NULL,
ProductName nvarchar(40) NULL,
ProductID int NULL,
SupplierName nvarchar(40) NULL,
CategoryName nvarchar(15) NULL,
ListUnitPrice money NULL,

CONSTRAINT PK_ProductDimension PRIMARY KEY NONCLUSTERED
(
ProductKey ASC
)) 

CREATE TABLE dbo.ShipperDimension(
ShipperKey int IDENTITY(1,1) NOT NULL,
ShipperName nvarchar(50) NOT NULL,
ShipperID int NOT NULL,

CONSTRAINT PK_ShipperDimension PRIMARY KEY NONCLUSTERED
(
ShipperKey ASC
))

CREATE TABLE dbo.TimeDimension(
TimeKey int IDENTITY(1,1) NOT NULL,
TheDate int NULL,
DayOfWeek int NULL,
DayOfWeekName nvarchar(30) NULL,
Month nvarchar(12) NULL,
MonthName nvarchar(30) NULL,
Year int NULL,
Quarter int NULL,
DayOfYear int NULL,
Weekday char(1) NULL,
WeekOfYear int NULL,

CONSTRAINT PK_TimeDimension PRIMARY KEY NONCLUSTERED
(
TimeKey ASC
))
ALTER TABLE SaleFact
ADD CONSTRAINT FK_SaleFact_CustomerDimension FOREIGN KEY (CustomerKey)
REFERENCES CustomerDimension(CustomerKey),
CONSTRAINT FK_SaleFact_EmployeeDimension FOREIGN KEY (EmployeeKey)
REFERENCES EmployeeDimension(EmployeeKey),
CONSTRAINT FK_SaleFact_ProductDimension FOREIGN KEY (ProductKey)
REFERENCES ProductDimension(ProductKey),
CONSTRAINT FK_SaleFact_ShipperDimension FOREIGN KEY (ShipperKey)
REFERENCES ShipperDimension(ShipperKey),
CONSTRAINT FK_SaleFact_TimeDimension FOREIGN KEY (TimeKey)
REFERENCES TimeDimension(TimeKey)
CREATE NONCLUSTERED INDEX IX_SaleFact_CustomerDimension
 ON SaleFact (CustomerKey);
CREATE NONCLUSTERED INDEX IX_SaleFact_EmployeeDimension
 ON SaleFact (EmployeeKey);
CREATE NONCLUSTERED INDEX IX_SaleFact_ProductDimension
 ON SaleFact (ProductKey);
CREATE NONCLUSTERED INDEX IX_SaleFact_ShipperDimension
 ON SaleFact (ShipperKey);
CREATE NONCLUSTERED INDEX IX_SaleFact_TimeDimension
 ON SaleFact (TimeKey);