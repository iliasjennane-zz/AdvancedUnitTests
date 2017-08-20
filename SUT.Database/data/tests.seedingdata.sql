SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].[Employees] ([Id], [Name], [Salary], [HireDate], [PerformanceStarLevel]) VALUES (1, N'Joe Doe', 100000, N'2010-07-07 00:00:00', 5)
INSERT INTO [dbo].[Employees] ([Id], [Name], [Salary], [HireDate], [PerformanceStarLevel]) VALUES (2, N'Jane Doe', 110000, N'2009-01-05 00:00:00', 4)
INSERT INTO [dbo].[Employees] ([Id], [Name], [Salary], [HireDate], [PerformanceStarLevel]) VALUES (3, N'Bob Man', 150000, N'1995-01-01 00:00:00', 2)
INSERT INTO [dbo].[Employees] ([Id], [Name], [Salary], [HireDate], [PerformanceStarLevel]) VALUES (4, N'Laurie Woman', 160000, N'2000-01-05 00:00:00', 1)
SET IDENTITY_INSERT [dbo].[Employees] OFF
