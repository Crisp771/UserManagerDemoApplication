CREATE TABLE [dbo].[Roles] (
    [Id]   INT           NOT NULL PRIMARY KEY CLUSTERED ([Id] ASC),
    [Name] NVARCHAR (50) NOT NULL
);

GO
CREATE TABLE [dbo].[Statuses] (
    [Id]   INT           NOT NULL PRIMARY KEY CLUSTERED ([Id] ASC),
    [Name] NVARCHAR (50) NOT NULL
);

GO
CREATE TABLE [dbo].[Users] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL PRIMARY KEY CLUSTERED ([Id] ASC),
    [Name]      NVARCHAR (150) NOT NULL,
    [RoleId]    INT            NOT NULL,
    [UpdatedAt] DATETIME       DEFAULT GETDATE() NOT NULL,
    [StatusId]  INT            NOT NULL,
    CONSTRAINT [FK_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]),
    CONSTRAINT [FK_Status] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Statuses] ([Id])
);

GO
