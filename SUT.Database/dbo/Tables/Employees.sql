CREATE TABLE [dbo].[Employees] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [Name]                 VARCHAR (MAX) NOT NULL,
    [Salary]               FLOAT (53)    NOT NULL,
    [HireDate]             DATETIME2 (7) NOT NULL,
    [PerformanceStarLevel] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

