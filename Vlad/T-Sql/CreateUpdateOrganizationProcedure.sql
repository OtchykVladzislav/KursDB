USE VladDb
GO
CREATE PROCEDURE UpdateProcedure
(
    @ID INT,
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
    UPDATE [dbo].[Organizations]
        SET OrganizationName = @NAME,
            OrganizationOwnership = @OWNERSHIP,
            OrganizationAdress = @ADRESS,
            OrganizationDirectorName = @DIRECTORNAME,
            OrganizationDirectorPhone = @DIRECTORPHONE,
            OrganizationSecretaryName = @SECRETARYNAME,
            OrganizationSecretaryPhone = @SECRETARYPHONE
        WHERE OrganizationId = @ID
END
GO
