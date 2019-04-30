SET IDENTITY_INSERT [dbo].[Dependents] ON
INSERT INTO [dbo].[Dependents] ([Id], [EmployeeId], [FirstName], [LastName], [Relationship]) VALUES (1, 3, N'Deanna', N'Troi', N'child')
INSERT INTO [dbo].[Dependents] ([Id], [EmployeeId], [FirstName], [LastName], [Relationship]) VALUES (2, 4, N'Alexander', N'Worf', N'child')
INSERT INTO [dbo].[Dependents] ([Id], [EmployeeId], [FirstName], [LastName], [Relationship]) VALUES (3, 5, N'Wesley', N'Crusher', N'child')
INSERT INTO [dbo].[Dependents] ([Id], [EmployeeId], [FirstName], [LastName], [Relationship]) VALUES (4, 7, N'Keiko', N'OBrien', N'spouse')
INSERT INTO [dbo].[Dependents] ([Id], [EmployeeId], [FirstName], [LastName], [Relationship]) VALUES (5, 8, N'Anton', N'Adams', NULL)
INSERT INTO [dbo].[Dependents] ([Id], [EmployeeId], [FirstName], [LastName], [Relationship]) VALUES (6, 8, N'Zachary', N'Adams', NULL)
INSERT INTO [dbo].[Dependents] ([Id], [EmployeeId], [FirstName], [LastName], [Relationship]) VALUES (7, 7, N'Robin', N'OBrien', N'Child')
INSERT INTO [dbo].[Dependents] ([Id], [EmployeeId], [FirstName], [LastName], [Relationship]) VALUES (8, 7, N'George', N'OBrien', N'Child')
INSERT INTO [dbo].[Dependents] ([Id], [EmployeeId], [FirstName], [LastName], [Relationship]) VALUES (9, 7, N'William', N'OBrien', N'Child')
INSERT INTO [dbo].[Dependents] ([Id], [EmployeeId], [FirstName], [LastName], [Relationship]) VALUES (1008, 7, N'Charlotte', N'OBrien', N'Child')
INSERT INTO [dbo].[Dependents] ([Id], [EmployeeId], [FirstName], [LastName], [Relationship]) VALUES (2008, 9, N'Adam', N'Uhura', N'Child')
SET IDENTITY_INSERT [dbo].[Dependents] OFF
