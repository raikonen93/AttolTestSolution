CREATE TABLE Customers (
    CustomerID bigint PRIMARY KEY, 
    CustomerName NVARCHAR(max) NOT NULL
);
Go


CREATE TABLE Categories (
    CategoryID bigint PRIMARY KEY,
    CategoryName NVARCHAR(max) NOT NULL
);
Go

CREATE TABLE Products (
    ProductID bigint PRIMARY KEY,
    ProductName NVARCHAR(max) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    CategoryID bigint,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
Go

CREATE TABLE Orders (
    OrderID bigint PRIMARY KEY,
    CustomerID bigint,
    OrderDate DATE NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
Go

CREATE TABLE OrderProducts (
    OrderID bigint,
    ProductID bigint,
    Quantity bigint NOT NULL,
    PRIMARY KEY (OrderID, ProductID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
Go

CREATE VIEW OrderSummary AS
SELECT 
    o.OrderID,
    o.OrderDate,
    c.CustomerName,
    SUM(op.Quantity * p.Price) AS TotalAmount
FROM 
    Orders o
JOIN 
    Customers c ON o.CustomerID = c.CustomerID
JOIN 
    OrderProducts op ON o.OrderID = op.OrderID
JOIN 
    Products p ON op.ProductID = p.ProductID
GROUP BY 
    o.OrderID, o.OrderDate, c.CustomerName;
GO