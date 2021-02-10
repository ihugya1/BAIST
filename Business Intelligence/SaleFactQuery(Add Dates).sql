	SELECT ihugya1.dbo.CustomerDimension.CustomerKey,
	ihugya1.dbo.EmployeeDimension.EmployeeKey,
	ihugya1.dbo.ProductDimension.ProductKey,
	ihugya1.dbo.ShipperDimension.ShipperKey,
	ihugya1.dbo.TimeDimension.TimeKey,
	Northwind.dbo.[Order Details].Quantity,
	Northwind.dbo.[Order Details].Discount,
	Northwind.dbo.Orders.Freight,
	Northwind.dbo.[Order Details].UnitPrice
	


	FROM ihugya1.dbo.CustomerDimension,
	ihugya1.dbo.EmployeeDimension,
	ihugya1.dbo.ProductDimension,
	ihugya1.dbo.ShipperDimension,
	ihugya1.dbo.TimeDimension,
	Northwind.dbo.Orders
	
	INNER JOIN Northwind.dbo.[Order Details] on Northwind.dbo.[Order Details].OrderID = Northwind.dbo.Orders.OrderID

	WHERE ihugya1.dbo.CustomerDimension.CustomerID = Northwind.dbo.Orders.CustomerID
	AND ihugya1.dbo.EmployeeDimension.EmployeeID = Northwind.dbo.Orders.EmployeeID
	AND ihugya1.dbo.ProductDimension.ProductID = Northwind.dbo.[Order Details].ProductID
	AND ihugya1.dbo.ShipperDimension.ShipperID = Northwind.dbo.Orders.ShipVia
	AND DATEFROMPARTS(ihugya1.dbo.TimeDimension.Year, ihugya1.dbo.TimeDimension.Month, ihugya1.dbo.TimeDimension.TheDate)
	= Convert(date, Northwind.dbo.Orders.OrderDate)