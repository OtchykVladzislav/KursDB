USE VladDb
GO
CREATE VIEW IndicatorsView AS
SELECT [dbo].[CounterIndications].[TargetCounterId] AS CounterId,
	   [dbo].[CounterIndications].[IndicationRate] AS IndRate,
	   [dbo].[IndicatorCheck].[CheckId] AS CheckId,
	   [dbo].[IndicatorCheck].[CheckDate] AS CheckDate,
	   [dbo].[IndicatorCheck].[CheckInfo] AS CheckInfo
FROM [dbo].[CounterIndications] INNER JOIN [dbo].[IndicatorCheck] 
	ON [dbo].[CounterIndications].[TargetCounterId] = [dbo].[IndicatorCheck].[IndicatorId]