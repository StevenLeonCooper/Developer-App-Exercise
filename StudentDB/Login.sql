CREATE LOGIN [api]
    WITH PASSWORD = N'SuperSecret321!',
    DEFAULT_DATABASE = [StudentDB]

GO
USE [StudentDB];
CREATE USER [User] FOR LOGIN [api];

GO
USE [StudentDB]
ALTER ROLE db_owner
	ADD MEMBER [User];  
GO
