USE VladDb;
GO

DECLARE @iterator INT = 1

WHILE @iterator <= 500
	BEGIN
		INSERT INTO [dbo].[Organizations]
			(OrganizationName,
			 OrganizationOwnership,
			 OrganizationAdress,
			 OrganizationDirectorName,
			 OrganizationDirectorPhone,
			 OrganizationSecretaryName,
			 OrganizationSecretaryPhone)
			VALUES (CONCAT('NAME', @iterator),
					CONCAT('ownership', @iterator),
					CONCAT('adress', @iterator),
					CONCAT('director', @iterator),
					CONCAT('directorPhone', @iterator),
					CONCAT('secretary', @iterator),
					CONCAT('secretaryPhone', @iterator)
					)
		SET @iterator = @iterator + 1
	END;
GO

DECLARE @iterator INT = 1

WHILE @iterator <= 20000
	BEGIN
		INSERT INTO [dbo].[CounterMarks]
					(CounterMarkName, CounterMarkBuilder, CounterMarkEndDate)
			VALUES (
					CONCAT('markName', CAST(@iterator AS NVARCHAR)),
					CONCAT('markBuilder', CAST(@iterator AS NVARCHAR)),
					DATEADD(day, @iterator, GETDATE())
					)
		SET @iterator = @iterator + 1
	END;
GO

DECLARE @iterator INT = 1

WHILE @iterator <= 20000
	BEGIN
		INSERT INTO [dbo].[Counters]
			(CounterMark, CounterSetupDate, CounterSetupPlace)
			VALUES (
					@iterator,
					DATEADD(day, @iterator, GETDATE()),
					CONCAT('place', CAST(@iterator AS NVARCHAR))
					)
		SET @iterator = @iterator + 1
	END;
GO

DECLARE @iterator INT = 1

WHILE @iterator <= 20000
	BEGIN
		INSERT INTO [dbo].[CounterIndications] 
			VALUES (@iterator,
					DATEADD(day, @iterator, GETDATE()),
					20,
					@iterator
					)
		SET @iterator = @iterator + 1
	END;
GO

DECLARE @iterator INT = 1

WHILE @iterator <= 20000
	BEGIN
		INSERT INTO [dbo].[IndicatorCheck] 
			VALUES (@iterator,
					@iterator,
					DATEADD(day, @iterator, GETDATE()),
					CONCAT('info', CAST(@iterator AS NVARCHAR))
					)
		SET @iterator = @iterator + 1
	END;
GO
