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