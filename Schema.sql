/*
    Lab 1 - Login, Registration & Logout
    Student: MD. Nazmus Sakib (24-58158-2)

    Run this complete script in SSMS while connected to:
    (LocalDB)\MSSQLLocalDB
*/

USE [master];
GO

IF DB_ID(N'24-58158-2_LoginDB') IS NULL
BEGIN
    CREATE DATABASE [24-58158-2_LoginDB];
END;
GO

USE [24-58158-2_LoginDB];
GO

IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users
    (
        UserID       INT IDENTITY(1,1) NOT NULL
            CONSTRAINT PK_Users PRIMARY KEY,
        Username     NVARCHAR(50) NOT NULL
            CONSTRAINT UQ_Users_Username UNIQUE,
        PasswordHash NVARCHAR(200) NOT NULL,
        Email        NVARCHAR(100) NULL,
        FullName     NVARCHAR(100) NULL,
        CreatedAt    DATETIME NOT NULL
            CONSTRAINT DF_Users_CreatedAt DEFAULT GETDATE()
    );
END;
GO

/* Bonus task: records each successful login and its logout time. */
IF OBJECT_ID(N'dbo.LoginHistory', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.LoginHistory
    (
        HistoryID INT IDENTITY(1,1) NOT NULL
            CONSTRAINT PK_LoginHistory PRIMARY KEY,
        UserID    INT NOT NULL,
        LoginTime DATETIME NOT NULL
            CONSTRAINT DF_LoginHistory_LoginTime DEFAULT GETDATE(),
        LogoutTime DATETIME NULL,
        CONSTRAINT FK_LoginHistory_Users
            FOREIGN KEY (UserID) REFERENCES dbo.Users(UserID)
    );
END;
GO

SELECT UserID, Username, Email, FullName, CreatedAt
FROM dbo.Users
ORDER BY UserID;
GO
