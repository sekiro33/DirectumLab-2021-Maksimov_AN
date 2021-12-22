/*1. Отобразить названия организации всех покупателей из Торонто*/
SELECT
	SalesLT.Customer.CompanyName
FROM 
	SalesLT.Customer 
JOIN
	SalesLT.CustomerAddress
ON 
	SalesLT.Customer.CustomerID = SalesLT.CustomerAddress.CustomerID
JOIN 
	SalesLT.Address
ON 
	SalesLT.CustomerAddress.AddressID = SalesLT.Address.AddressID
WHERE 
	SalesLT.Address.City = 'Toronto';

/*2. Сколько товаров со стоимостью (ListPrice) выше 1000 было продано?*/;
SELECT 
	COUNT(*) 
FROM 
	SalesLT.SalesOrderDetail 
JOIN 
	SalesLT.Product 
ON	
	SalesLT.SalesOrderDetail.ProductID = SalesLT.Product.ProductID 
WHERE 
	SalesLT.Product.ListPrice > 1000

/*3. Отобразить названия организаций, суммарные покупки которых (включая налоги), превысили 50000.*/
SELECT 
	SalesLT.Customer.CompanyName, 
	SalesLT.SalesOrderHeader.TotalDue 
FROM 
	SalesLT.SalesOrderHeader 
JOIN 
	SalesLT.Customer 
ON 
	SalesLT.SalesOrderHeader.CustomerID = SalesLT.Customer.CustomerID 
WHERE 
	SalesLT.SalesOrderHeader.TotalDue > 50000

/*4. Какие компании заказывали продукт (ProductModel) "Racing Socks"?*/
SELECT 
	SalesLT.Customer.CompanyName 
FROM 
	SalesLT.SalesOrderHeader 
JOIN 
	SalesLT.SalesOrderDetail 
ON 
	SalesLT.SalesOrderHeader.SalesOrderID = SalesLT.SalesOrderDetail.SalesOrderID
JOIN   
	(SELECT SalesLT.Product.ProductID, SalesLT.ProductModel.Name 
	FROM SalesLT.Product 
	JOIN SalesLT.ProductModel 
	ON SalesLT.Product.ProductModelID = SalesLT.ProductModel.ProductModelID
	WHERE SalesLT.ProductModel.Name = 'Racing Socks') AS Product 
ON 
	SalesLT.SalesOrderDetail.ProductID = Product.ProductID
JOIN
	SalesLT.Customer
ON 
	SalesLT.SalesOrderHeader.CustomerID = SalesLT.Customer.CustomerID

/*5. Отобразить 25 товаров с наибольшим суммарным чеком (количество * стоимость товара)*/
SELECT 
	TOP(25)
	SalesLT.Product.ProductID,
	SalesLT.Product.Name,
	SalesLT.SalesOrderDetail.OrderQty * SalesLT.SalesOrderDetail.UnitPrice AS Total
FROM 
	SalesLT.SalesOrderDetail
JOIN
	SalesLT.Product
ON
	SalesLT.Product.ProductID = SalesLT.SalesOrderDetail.ProductID
ORDER BY 
	SalesLT.SalesOrderDetail.OrderQty * SalesLT.SalesOrderDetail.UnitPrice
DESC

/*6. Сгруппировать заказы по диапазону стоимости: 0..99, 100..999, 1000..9999, свыше 10000.
Для каждого диапазона отобразить количество заказов и общую стоимость.*/
SELECT 
	CASE WHEN SalesLT.SalesOrderDetail.LineTotal <= 99 THEN '0..99'
		 WHEN SalesLT.SalesOrderDetail.LineTotal <= 999 THEN '100..999'
		 WHEN SalesLT.SalesOrderDetail.LineTotal <= 9999 THEN '1000..9999'
		 ELSE 'More 10000'
	END AS Total,
	COUNT (*) AS Count
FROM
	SalesLT.SalesOrderDetail
GROUP BY
	CASE WHEN SalesLT.SalesOrderDetail.LineTotal <= 99 THEN '0..99'
		 WHEN SalesLT.SalesOrderDetail.LineTotal <= 999 THEN '100..999'
		 WHEN SalesLT.SalesOrderDetail.LineTotal <= 9999 THEN '1000..9999'
		 ELSE 'More 10000'
	END
	
/*7. Отобразить список компаний, содержащий 'bike' или 'cycle' в названии. 
Отсортировать выборку так, чтобы сначала отображались компании с 'bike', а затем с 'cycle.*/
SELECT 
	CompanyName
FROM 
	SalesLT.Customer 
WHERE 
	SalesLT.Customer.CompanyName LIKE '%bike%' OR SalesLT.Customer.CompanyName LIKE '%cycle%'
ORDER BY
	CHARINDEX('cycle', SalesLT.Customer.CompanyName)

/*8. Отобразить 10 наиболее важных для продаж городов.*/
SELECT 
	TOP(10) 
	SalesLT.Address.City,
	SalesLT.SalesOrderHeader.TotalDue
FROM 
	SalesLT.SalesOrderHeader 
JOIN 
	SalesLT.CustomerAddress 
ON 
	SalesLT.SalesOrderHeader.CustomerID = SalesLT.CustomerAddress.CustomerID 
JOIN 
	SalesLT.Address 
ON 
	SalesLT.CustomerAddress.AddressID = SalesLT.Address.AddressID 
ORDER BY 
	SalesLT.SalesOrderHeader.TotalDue 
DESC;