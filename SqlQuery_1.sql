-- Create the Products table
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(50),
    UnitPrice DECIMAL,
    StockQuantity DECIMAL
);

-- Create the Sales_Head table
CREATE TABLE Sales_Head (
    SaleID INT IDENTITY(1,1) PRIMARY KEY,
    BillDate DATETIME,
    CustomerName NVARCHAR(100),
    Mob NVARCHAR(20),
    Address TEXT
);

-- Create the Sales_Line table
CREATE TABLE Sales_Line (
    SaleID INT,
    LineId INT,
    ProductID INT,
    Quantity INT,
    UnitPrice DECIMAL,
    TotalPrice DECIMAL,
    PRIMARY KEY (SaleID, LineId),
    FOREIGN KEY (SaleID) REFERENCES Sales_Head(SaleID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);