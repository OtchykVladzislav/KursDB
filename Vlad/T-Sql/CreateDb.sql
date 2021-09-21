CREATE DATABASE VladDb;
GO

USE VladDb;
GO

CREATE TABLE [dbo].[Organizations] (
    [OrganizationId] INT IDENTITY (1, 1) NOT NULL,
    [OrganizationName] NVARCHAR (MAX) NULL,
    [OrganizationOwnership] NVARCHAR (MAX) NULL,
    [OrganizationAdress] NVARCHAR (MAX) NULL,
    [OrganizationDirectorName] NVARCHAR (MAX) NULL,
    [OrganizationDirectorPhone] NVARCHAR (MAX) NULL,
    [OrganizationSecretaryName] NVARCHAR (MAX) NULL,
    [OrganizationSecretaryPhone] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED ([OrganizationId] ASC)
);
GO

CREATE TABLE [dbo].[CounterMarks] (
    [CounterMarkId] INT IDENTITY (1, 1) NOT NULL,
    [CounterMarkName] NVARCHAR (MAX) NULL,
    [CounterMarkBuilder] NVARCHAR (MAX) NULL,
    [CounterMarkEndDate] DATE NULL,
    CONSTRAINT [PK_CounterMarks] PRIMARY KEY CLUSTERED ([CounterMarkId] ASC)
);
GO

CREATE TABLE [dbo].[Counters] (
    [CounterId] INT IDENTITY (1, 1) NOT NULL,   
    [CounterMark] INT NOT NULL,
    [CounterSetupDate] DATE NULL,
    [CounterSetupPlace] varchar(45) NULL,
    CONSTRAINT [PK_Counters] PRIMARY KEY CLUSTERED ([CounterId] ASC),
    CONSTRAINT [FK_Counters_CounterMarks_CounterMarkId] FOREIGN KEY ([CounterMark]) REFERENCES [dbo].[CounterMarks] ([CounterMarkId]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[CounterIndications] (
    TargetCounterId INT NOT NULL,
    IndicationDate DATE NULL,
    IndicationRate INT NULL,
    IndicationResult INT NULL,
    CONSTRAINT [PK_CounterIndications] PRIMARY KEY CLUSTERED ([TargetCounterId] ASC),
    CONSTRAINT [FK_CounterIndication_TargetCounterId_CounterId] FOREIGN KEY ([TargetCounterId]) REFERENCES [dbo].[Counters] ([CounterId]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[IndicatorCheck] (
    CheckId INT NOT NULL,
    IndicatorId INT NOT NULL,
    CheckDate DATE NULL,
    CheckInfo NVARCHAR (45) NULL,
    CONSTRAINT [PK_IndicatorCheck] PRIMARY KEY CLUSTERED ([CheckId] ASC),
    CONSTRAINT [FK_IndicatorCheck_CounterIndications_CounterId] FOREIGN KEY ([IndicatorId]) REFERENCES [dbo].[CounterIndications] ([TargetCounterId]) ON DELETE CASCADE
);
GO