/* I know this is unconventional but I wanted this to be as simple as possible to set up
    and slapping everyting in a big SQL script makes it pretty easy to setup the database
    and test the app out. */

IF EXISTS (SELECT * FROM sysobjects WHERE name='contact' and xtype='U')

DROP TABLE [dbo].[contact];

GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='student' and xtype='U')

DROP TABLE [dbo].[student];

GO


CREATE TABLE [dbo].[student]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [StudentId] INT UNIQUE NOT NULL, 
    [FirstName] NVARCHAR(255) NOT NULL, 
    [LastName] NVARCHAR(512) NOT NULL, 
    [Address] NVARCHAR(512) NULL, 
    [City] NVARCHAR(256) NULL, 
    [State] NVARCHAR(2) NULL, 
    [Zip] VARCHAR(10) NULL, 
    [SchoolCode] INT NULL
);

CREATE INDEX [IX_student_StudentId] ON [dbo].[student] ([StudentId])

GO


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

GO

INSERT INTO [dbo].[student] ([Id],[SchoolCode],[StudentId],[LastName],[FirstName],[Address],[City],[State],[Zip])

VALUES
(DEFAULT,'994','99400001','Abbott','Allan','1118 Glenview Lane','Eagle Rock','CA','99999'),
(DEFAULT,'994','99400011','Abrahamson','Arnold','1126 E Walton Rd.','Eagle Rock','CA','99999'),
(DEFAULT,'994','99400012','Abrego','Alice','115 W Norgate St','Eagle Rock','CA','99999'),
(DEFAULT,'994','99400013','Abrego','Ivette','13642 Green Valley B','Eagle Rock','CA','99999'),
(DEFAULT,'994','99400014','AbuJohn','Edgar','1123 N Barston Ave','Eagle Rock','CA','99999'),
(DEFAULT,'994','99400015','Aceves','Steven','1110 Avenida Loma Vista','Eagle Rock','CA','99999');

INSERT INTO [dbo].[contact] ([Id],[StudentId],[LastName],[FirstName],[Relationship],[Email],[Mobile],[Address],[City],[State],[Zip])

VALUES

(DEFAULT,99400001,'Abbott','Sara','Mother','sara@example.com','949-123-45678','1118 Glenview Lane ','Eagle Rock','CA','99999'),
(DEFAULT,99400001,'Abbott','Adam','Father','adam@example.com','949-123-45679','1118 Glenview Lane ','Eagle Rock','CA','99999'),
(DEFAULT,99400011,'Abrahamson','Jonathan','Uncle','jonathan@example.com','949-234-4567','1126 E Walton Rd. ','Eagle Rock','CA','99999'),
(DEFAULT,99400012,'Acosta','Christine','Mother','christine@example.com','949-345-6789','115 W Norgate St ','Eagle Rock','CA','99999'),
(DEFAULT,99400013,'Abrego','Rezvan','Father','rezvan@example.com','949-456-7891','13642 Green Valley B ','Eagle Rock','CA','99999'),
(DEFAULT,99400014,'AbuJohn','Selina','Mother','selina@example.com','949-567-8912','1123 N Barston Ave ','Eagle Rock','CA','99999'),
(DEFAULT,99400015,'Aceves','Jacob','Father','jacob@example.com','949-678-9123','1110 Avenida Loma Vista ','Eagle Rock','CA','99999');

GO

CREATE OR ALTER PROCEDURE [dbo].[Get_Student_List]
AS
	SELECT * FROM student
RETURN 0


GO

CREATE OR ALTER PROCEDURE [dbo].[Get_Student_Contacts]
	@param1 int = 0
AS
	SELECT * FROM contact 
	WHERE [StudentId] = @param1
	ORDER BY [LastName] ASC
RETURN 0

GO