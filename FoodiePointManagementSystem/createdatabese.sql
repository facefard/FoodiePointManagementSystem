-- ============================================
-- Step 1: FoodiePointDB を作成する
-- ============================================
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'FoodiePointDB')
BEGIN
    CREATE DATABASE FoodiePointDB;
END
GO

USE FoodiePointDB;
GO

-- ============================================
-- Step 2: Users テーブルの作成
-- ============================================
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
    DROP TABLE dbo.Users;
GO

CREATE TABLE dbo.Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,  -- パスワードは必要に応じてハッシュ化を検討
    Role NVARCHAR(30) CHECK (Role IN ('Admin', 'Manager', 'Chef', 'Reservation Coordinator', 'Customer')),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- ============================================
-- Step 3: Sales テーブルの作成（売上レポート用）
-- ============================================
IF OBJECT_ID('dbo.Sales', 'U') IS NOT NULL
    DROP TABLE dbo.Sales;
GO

CREATE TABLE dbo.Sales (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    SaleDate DATETIME NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Chef NVARCHAR(50),
    TotalAmount DECIMAL(10,2) NOT NULL
);
GO

-- ============================================
-- Step 4: Feedback テーブルの作成（顧客フィードバック用）
-- ============================================
IF OBJECT_ID('dbo.Feedback', 'U') IS NOT NULL
    DROP TABLE dbo.Feedback;
GO

CREATE TABLE dbo.Feedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    Comments NVARCHAR(500) NOT NULL,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    FeedbackDate DATETIME DEFAULT GETDATE()
);
GO

-- ============================================
-- Step 5: Reservations テーブルの作成（予約管理用）
-- ============================================
IF OBJECT_ID('dbo.Reservations', 'U') IS NOT NULL
    DROP TABLE dbo.Reservations;
GO

CREATE TABLE dbo.Reservations (
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,  -- 必要に応じて FOREIGN KEY (Users)
    ReservationDate DATETIME NOT NULL,
    Guests INT NOT NULL CHECK (Guests > 0),
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Confirmed', 'Cancelled'))
);
GO

-- ============================================
-- Step 6: Menu テーブルの作成（メニュー管理用）
-- ============================================
IF OBJECT_ID('dbo.Menu', 'U') IS NOT NULL
    DROP TABLE dbo.Menu;
GO

CREATE TABLE dbo.Menu (
    MenuID INT PRIMARY KEY IDENTITY(1,1),
    ItemName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Availability BIT DEFAULT 1
);
GO

-- ============================================
-- Step 7: Orders テーブルの作成（注文管理用）
-- ============================================
IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL
    DROP TABLE dbo.Orders;
GO

CREATE TABLE dbo.Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,  -- 必要に応じて FOREIGN KEY (Users)
    OrderDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) CHECK (Status IN ('Pending', 'In Progress', 'Completed'))
);
GO

-- ============================================
-- Step 8: OrderDetails テーブルの作成（注文詳細）
-- ============================================
IF OBJECT_ID('dbo.OrderDetails', 'U') IS NOT NULL
    DROP TABLE dbo.OrderDetails;
GO

CREATE TABLE dbo.OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    MenuID INT NOT NULL,
    Quantity INT NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES dbo.Orders(OrderID),
    FOREIGN KEY (MenuID) REFERENCES dbo.Menu(MenuID)
);
GO

-- ============================================
-- Step 9: Inventory テーブルの作成（在庫管理用）
-- ============================================
IF OBJECT_ID('dbo.Inventory', 'U') IS NOT NULL
    DROP TABLE dbo.Inventory;
GO

CREATE TABLE dbo.Inventory (
    IngredientID INT PRIMARY KEY IDENTITY(1,1),
    IngredientName NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity >= 0),
    Price DECIMAL(10,2) NOT NULL,
    LastUpdated DATETIME DEFAULT GETDATE()
);
GO

-- ============================================
-- Step 10: サンプルデータの挿入 (Users テーブル)
-- ============================================
INSERT INTO dbo.Users (UserName, Email, Password, Role)
VALUES 
('admin', 'admin@example.com', 'Admin123!', 'Admin'),
('manager', 'manager@example.com', 'Manager123!', 'Manager'),
('chef', 'chef@example.com', 'Chef123!', 'Chef'),
('coordinator', 'coordinator@example.com', 'Coordinator123!', 'Reservation Coordinator'),
('customer', 'customer@example.com', 'Customer123!', 'Customer');
GO
