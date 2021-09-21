USE VladDb
GO
CREATE VIEW CountersView AS
SELECT [dbo].[CounterMarks].[CounterMarkName] AS MarkName,
	   [dbo].[CounterMarks].[CounterMarkBuilder] AS MarkBuilder,
	   [dbo].[Counters].[CounterSetupDate] AS SetupDate,
	   [dbo].[Counters].[CounterSetupPlace] AS SetupPlace
FROM [dbo].[Counters] INNER JOIN [dbo].[CounterMarks] 
	ON [dbo].[Counters].[CounterMark] = [dbo].[CounterMarks].[CounterMarkId] 
	   