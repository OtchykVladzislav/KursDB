USE VladDb
GO
CREATE VIEW CounterDateFilterView AS
SELECT *
FROM [dbo].[Counters] WHERE [dbo].[Counters].[CounterSetupDate] = GETDATE()
	   