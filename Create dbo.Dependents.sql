USE [PayrollData]
GO

/****** Object: Table [dbo].[Dependents] Script Date: 4/29/2019 8:25:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dependents] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeId]   INT            NOT NULL,
    [FirstName]    NVARCHAR (MAX) NULL,
    [LastName]     NVARCHAR (MAX) NULL,
    [Relationship] NVARCHAR (MAX) NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_Dependents_EmployeeId]
    ON [dbo].[Dependents]([EmployeeId] ASC);


GO
ALTER TABLE [dbo].[Dependents]
    ADD CONSTRAINT [PK_Dependents] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[Dependents]
    ADD CONSTRAINT [FK_Dependents_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([Id]) ON DELETE CASCADE;


