

SELECT        DISTINCT OrderDate, DATEPART(dd, OrderDate) AS TheDate, DATEPART(dw, OrderDate) AS DayOfWeek, DATENAME(dw, OrderDate) AS DayOfWeekName, DATEPART(m, OrderDate) AS Month, DATENAME(m, OrderDate) AS MonthName, 
                         YEAR(OrderDate) AS Year, DATEPART(q, OrderDate) AS Quarter, DATEPART(dy, OrderDate) AS DayOfYear, IIF(DATEPART(dw, OrderDate) = 1 OR
                         DATEPART(dw, OrderDate) = 7, 'Y', 'N') AS Weekday, DATEPART(wk, OrderDate) AS WeekOfYear
FROM            Orders