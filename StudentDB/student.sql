CREATE TABLE [dbo].[student]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [StudentId] INT NOT NULL, 
    [FirstName] NVARCHAR(255) NOT NULL, 
    [LastName] NVARCHAR(512) NOT NULL, 
    [Address] NVARCHAR(512) NULL, 
    [City] NVARCHAR(256) NULL, 
    [State] NVARCHAR(2) NULL, 
    [Zip] VARCHAR(10) NULL, 
    [SchoolCode] INT NULL
)

GO
