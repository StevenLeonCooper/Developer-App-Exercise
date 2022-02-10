CREATE TABLE [dbo].[contact]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [StudentId] INT NOT NULL, 
    [LastName] VARCHAR(512) NULL, 
    [FirstName] VARCHAR(255) NULL, 
    [Relationship] VARCHAR(128) NULL, 
    [Email] VARCHAR(255) NULL, 
    [Mobile] VARCHAR(20) NULL, 
    [Address] VARCHAR(512) NULL, 
    [City] VARCHAR(256) NULL, 
    [State] VARCHAR(2) NULL, 
    [Zip] VARCHAR(10) NULL, 
    CONSTRAINT [FK_contact2student] FOREIGN KEY ([StudentId]) REFERENCES [student]([StudentId])
)
