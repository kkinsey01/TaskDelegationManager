USE Master
GO

IF DB_ID('TaskDelegation') IS NOT NULL
DROP DATABASE TaskDelegation
GO

CREATE DATABASE TaskDelegation
GO

USE TaskDelegation
GO

CREATE TABLE Users (
	UserID INT PRIMARY KEY IDENTITY,
	UserName VARCHAR(255) NOT NULL UNIQUE,
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL,
	Email VARCHAR(MAX) NOT NULL,
	Password VARCHAR(MAX) NOT NULL,
	NumberOfTasks INT NOT NULL,
	TasksComplete INT NOT NULL,	
)
GO

CREATE TABLE Tasks (
	TaskID INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	Description VARCHAR(MAX) NULL,
	Status VARCHAR(50) NOT NULL,
	Priority VARCHAR(50) NOT NULL,
	GivenTo INT REFERENCES Users (UserID),
	CreatedBy INT REFERENCES Users (UserID),	
	DateCreated DateTime NOT NULL,
	Deadline DateTime NOT NULL,
	DateComplete DateTime NULL,
	Recurring Bit NOT NULL,
	Edited Bit NOT NULL,
)
GO

CREATE TABLE Comments (
	CommentID INT PRIMARY KEY IDENTITY,
	TaskID INT REFERENCES Tasks (TaskID),
	UserID INT REFERENCES Users (UserID),
	Content VARCHAR(MAX) NULL,
	TimeStamp DateTime NULL
)
GO

CREATE TABLE Permissions (
	PermissionID INT PRIMARY KEY IDENTITY,
	Permission VARCHAR(50) NOT NULL,
)
GO

CREATE TABLE UserPermissions (
	UserPermissionsID INT PRIMARY KEY IDENTITY,
	UserID INT REFERENCES Users (UserID),
	PermissionID INT REFERENCES Permissions (PermissionID)
)
GO

INSERT INTO Users
VALUES ('dev', 'dev', 'dev', 'dev@local.com', 'dev', 1, 1),
	('admin', 'admin', 'admin', 'admin@local.com', 'admin', 1, 1)

INSERT INTO Permissions
VALUES ('devadmin'), 
	('admin')
GO

INSERT INTO UserPermissions (UserID, PermissionID)
Select 
	(Select UserID from Users where UserName = 'dev'),
	(Select PermissionID from Permissions where Permission = 'devadmin')

Insert INTO UserPermissions (UserID, PermissionID)
SELECT 
	(SELECT UserID from Users where UserName = 'admin'),
	(SELECT PermissionID from Permissions where Permission = 'admin')




