use Sales;
/*�������� ���� �����*/
/*������� - ���������*/
CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30) NOT NULL,
	City NVARCHAR(30) NOT NULL
);

/*������� - ��������*/
CREATE TABLE Sellers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30) NOT NULL,
	City NVARCHAR(30) NOT NULL,
	Commission FLOAT NOT NULL
);

/*������� - ������*/
CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY,
	Description NVARCHAR(30) NOT NULL,
	TotalSum MONEY NOT NULL CHECK (TotalSum >= 0),
	CreatedAt DATETIME NOT NULL,
	Customer INT REFERENCES Customers(Id),
	Seller INT REFERENCES Sellers(Id)
);

/*������� - ������� �������*/
CREATE TABLE OrderHistory
(
	OrderId INT NOT NULL,
	Action NVARCHAR(10) NOT NULL,
	ChangedAt DATETIME NOT NULL,
	OrderedAt DATETIME NOT NULL,
	Customer INT REFERENCES Customers(Id),
	Seller INT REFERENCES Sellers(Id),
	PRIMARY KEY (OrderId, Action, ChangedAt)
);


/*���������� ���������*/
/*��� ���������� ������ � ������� ������, ����� ��������� ��������
�� ������������ ������� �������� � ���������, � �����, � ������
������� ����������� ��������, ����� ��������� ������ � �������.*/
CREATE TRIGGER AddOrders
	ON dbo.Orders
	AFTER INSERT
	AS
BEGIN
	DECLARE @count INT
	DECLARE @count1 INT
	SET @count = (SELECT COUNT(*) FROM inserted)
	SET @count1 = (SELECT COUNT(*) FROM inserted
				   JOIN dbo.Customers ON dbo.Customers.Id = inserted.Customer
				   JOIN dbo.Sellers ON dbo.Sellers.Id = inserted.Seller
				   WHERE dbo.Customers.City = dbo.Sellers.City)
	/*���� ���������� ����������� ������� ����� ���������� ������� ����� �������� - �� �� ��*/
	IF (@count = @count1)
	INSERT INTO	dbo.OrderHistory(OrderId, Action, ChangedAt, OrderedAt, Customer, Seller)
		(SELECT Id, 'INSERT', GETDATE(), CreatedAt, Customer, Seller FROM inserted) 
	ELSE
		THROW 51000, '�� ������������ ������� �������� � ����������.', 1;  
END

/*������� �� ��������� ������ � ������� ������*/
CREATE TRIGGER UpdateOrders
ON dbo.Orders
AFTER UPDATE
AS
BEGIN
	INSERT INTO	dbo.OrderHistory(OrderId, Action, ChangedAt, OrderedAt, Customer, Seller)
		SELECT Id, 'UPDATE', GETDATE(), CreatedAt, Customer, Seller FROM deleted 
END

/*������� �� �������� ������ �� ������� ������*/
CREATE TRIGGER DeleteOrders
ON dbo.Orders
AFTER DELETE
AS
BEGIN
	INSERT INTO	dbo.OrderHistory(OrderId, Action, ChangedAt, OrderedAt, Customer, Seller)
		SELECT Id, 'DELETE', GETDATE(), CreatedAt, Customer, Seller FROM deleted 
END

/*���������� ������������� ������������ ������� �� ���������*/
CREATE VIEW GetSellersInfo
AS
SELECT
	dbo.Sellers.Id,
	dbo.Sellers.FirstName,
	dbo.Sellers.MiddleName,
	dbo.Sellers.LastName,
	dbo.Sellers.Commission,
	SUM(dbo.Orders.TotalSum * dbo.Sellers.Commission / 100) as CommissionSum
FROM 
	dbo.Orders 
JOIN 
	dbo.Sellers 
ON 
	dbo.Orders.Seller = dbo.Sellers.Id 
GROUP BY 
	dbo.Sellers.Id, 		
	dbo.Sellers.FirstName,
	dbo.Sellers.MiddleName,
	dbo.Sellers.LastName,
	dbo.Sellers.Commission

/*���������� �������� ���������, ������������ ������� ������� �� ������������� ������*/
CREATE PROCEDURE GetOrdersByCity
	@city NVARCHAR(30)
AS
SELECT 
	dbo.Orders.Id, 
	dbo.Orders.Description, 
	dbo.Orders.TotalSum, 
	dbo.Orders.CreatedAt, 
	dbo.Customers.City 
FROM dbo.Orders 
JOIN dbo.Customers 
ON dbo.Orders.Customer = dbo.Customers.Id
WHERE dbo.Customers.City = @city


/*���������� ������ �������*/
/*������� ���������*/
INSERT INTO 
	dbo.Customers 
VALUES 
	('����', '������', '��������', '������'),
	('�������', '������', '����������', '������'),
	('����', '�������', '�������������', '������������'),
	('����', '������', '���������', '����'),
	('�����', '��������', '��������', '�����')

/*������� ��������*/
INSERT INTO 
	dbo.Sellers
VALUES 
	('������', '���������', '��������', '������', 3.2),
	('�����', '���������', '����������', '������', 2.1),
	('������', '��������', '��������', '������������', 3.3),
	('�����', '������', '���������', '����', 5.2),
	('�����', '�������', '���������', '�����', 4.3)

/*������� ������*/
INSERT INTO
	dbo.Orders
VALUES
	('�������� �������� ������ �1', 345240, GETDATE(), 1, 2),
	('�������� �������� ������ �2', 4568712, GETDATE(), 4, 4),
	('�������� �������� ������ �3', 789000, GETDATE(), 3, 3)
