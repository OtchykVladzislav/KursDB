USE VladDb
GO
CREATE PROCEDURE InsertMarkProcedure
(
    @MARK NVARCHAR,
    @SETUP DATE,
    @PLACE NVARCHAR
)
AS
BEGIN
    INSERT INTO [dbo].[Counters]
			(CounterMark, CounterSetupDate, CounterSetupPlace)
            VALUES (@MARK, @SETUP, @PLACE)
END

GO
