
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Mylibrary')
BEGIN
    CREATE DATABASE Mylibrary;
END
GO

USE Mylibrary;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Books')
BEGIN
    CREATE TABLE Books (
        Id INT IDENTITY PRIMARY KEY,
        Name NVARCHAR(200),
        Arthur NVARCHAR(150),
        Page INT,
        Pages INT,
        [Starting Date] DATETIME,
        [Finishing Date] DATETIME
    );
END
GO