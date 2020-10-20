use Northwind

CREATE PROCEDURE ihugya1.GetProductByCategories(@CategoryID int = NULL)  
AS   
 DECLARE @RETURNCODE INT  
 SET @RETURNCODE = 1  
  
 IF @CategoryID IS NULL  
  RAISERROR('GetProductByCategories - Required parameter: @CategoryID' ,16,1)  
 ELSE  
  BEGIN  
   SELECT ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued 
   FROM Products 
   WHERE CategoryID = @CategoryID  
  
   IF @@ERROR = 0  
    SET @RETURNCODE = 0  
   ELSE  
    RAISERROR('GetProductByCategories - SELECT Error : Categories table.',16,1)  
  END  
 RETURN @ReturnCode
