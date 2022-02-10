CREATE PROCEDURE [dbo].[Get_Student_Contacts]
	@param1 int = 0
AS
	SELECT * FROM contact 
	WHERE [StudentId] = @param1
	ORDER BY [LastName] ASC
RETURN 0
