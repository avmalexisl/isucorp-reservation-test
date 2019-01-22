CREATE PROCEDURE [dbo].[GetContact]
	@Id int = 0
AS
	SELECT Id,
           Name,
           Phone,
           BirthDate,
           Type,
           Description FROM Contacts
	WHERE Contacts.Id = @Id