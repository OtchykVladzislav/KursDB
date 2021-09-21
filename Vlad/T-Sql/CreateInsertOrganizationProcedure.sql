USE VladDb
GO
CREATE PROCEDURE TestProcedure 
(
    @NAME NVARCHAR,
    @OWNERSHIP NVARCHAR,
    @ADRESS NVARCHAR,
    @DIRECTORNAME NVARCHAR,
    @DIRECTORPHONE NVARCHAR,
    @SECRETARYNAME NVARCHAR,
    @SECRETARYPHONE NVARCHAR
)
AS
BEGIN
    INSERT INTO [dbo].[Organizations] (OrganizationName,
			 OrganizationOwnership,
			 OrganizationAdress,
			 OrganizationDirectorName,
			 OrganizationDirectorPhone,
			 OrganizationSecretaryName,
			 OrganizationSecretaryPhone)
            VALUES (@NAME, @OWNERSHIP, @ADRESS, @DIRECTORNAME, @DIRECTORPHONE, @SECRETARYNAME, @SECRETARYPHONE)
END

GO
