/*1. Отобразить названия организации всех покупателей из Торонто*/
select
  SalesLT.Customer.CompanyName
from 
  SalesLT.Customer 
  join SalesLT.CustomerAddress on SalesLT.Customer.CustomerID = SalesLT.CustomerAddress.CustomerID
  join SalesLT.Address on SalesLT.CustomerAddress.AddressID = SalesLT.Address.AddressID
where 
  SalesLT.Address.City = 'Toronto';

/*2. Сколько товаров со стоимостью (ListPrice) выше 1000 было продано?*/;
select 
  sum(OrderQty)
from 
  SalesLT.SalesOrderDetail 
  join SalesLT.Product on SalesLT.SalesOrderDetail.ProductID = SalesLT.Product.ProductID 
where 
  SalesLT.Product.ListPrice > 1000

/*3. Отобразить названия организаций, суммарные покупки которых (включая налоги), превысили 50000.*/
select
  SalesLT.Customer.CompanyName
from
  SalesLT.SalesOrderHeader
  join SalesLT.Customer on SalesLT.SalesOrderHeader.CustomerID = SalesLT.Customer.CustomerID
group by
  SalesLT.Customer.CompanyName
having
  sum(SalesLT.SalesOrderHeader.TotalDue) > 50000

/*4. Какие компании заказывали продукт (ProductModel) "Racing Socks"?*/
select 
  SalesLT.Customer.CompanyName 
from 
  SalesLT.SalesOrderHeader 
  join SalesLT.SalesOrderDetail on SalesLT.SalesOrderHeader.SalesOrderID = SalesLT.SalesOrderDetail.SalesOrderID
  join SalesLT.Product on SalesLT.SalesOrderDetail.ProductID = SalesLT.Product.ProductID
  join SalesLT.ProductModel on SalesLT.Product.ProductModelID = SalesLT.ProductModel.ProductModelID
  join SalesLT.Customer on SalesLT.SalesOrderHeader.CustomerID = SalesLT.Customer.CustomerID
where 
  SalesLT.ProductModel.Name = 'Racing Socks'

/*5. Отобразить 25 товаров с наибольшим суммарным чеком (количество * стоимость товара)*/
select top(25)
  SalesLT.Product.Name,
  sum(SalesLT.SalesOrderDetail.OrderQty * SalesLT.SalesOrderDetail.UnitPrice) as Total
from 
  SalesLT.SalesOrderDetail
  join SalesLT.Product on SalesLT.Product.ProductID = SalesLT.SalesOrderDetail.ProductID
group by
  SalesLT.Product.Name
order by Total desc

/*6. Сгруппировать заказы по диапазону стоимости: 0..99, 100..999, 1000..9999, свыше 10000.
Для каждого диапазона отобразить количество заказов и общую стоимость.*/
select 
  case when SalesLT.SalesOrderHeader.TotalDue <= 99 then '0..99'
	   when SalesLT.SalesOrderHeader.TotalDue <= 999 then '100..999'
	   when SalesLT.SalesOrderHeader.TotalDue <= 9999 then '1000..9999'
	   else 'More 10000'
  end as Cost,
  count(SalesLT.SalesOrderHeader.TotalDue) as Count,
  sum(SalesLT.SalesOrderHeader.TotalDue) as TotalCost
from
  SalesLT.SalesOrderHeader
group by
  case when SalesLT.SalesOrderHeader.TotalDue <= 99 then '0..99'
	   when SalesLT.SalesOrderHeader.TotalDue <= 999 then '100..999'
	   when SalesLT.SalesOrderHeader.TotalDue <= 9999 then '1000..9999'
	   else 'More 10000'
  end

/*7. Отобразить список компаний, содержащий 'bike' или 'cycle' в названии. 
Отсортировать выборку так, чтобы сначала отображались компании с 'bike', а затем с 'cycle.*/
select 
  CompanyName
from 
  SalesLT.Customer 
where 
  SalesLT.Customer.CompanyName like '%bike%' or SalesLT.Customer.CompanyName like '%cycle%'
order by
  charindex('cycle', SalesLT.Customer.CompanyName)

/*8. Отобразить 10 наиболее важных для продаж городов.*/
select top(10) 
  SalesLT.Address.City,
  sum(SalesLT.SalesOrderHeader.TotalDue) as 'Sum'
from 
  SalesLT.SalesOrderHeader 
  join SalesLT.CustomerAddress on SalesLT.SalesOrderHeader.CustomerID = SalesLT.CustomerAddress.CustomerID 
  join SalesLT.Address on SalesLT.CustomerAddress.AddressID = SalesLT.Address.AddressID 
group by
  SalesLT.Address.City
order by 
  Sum
desc;