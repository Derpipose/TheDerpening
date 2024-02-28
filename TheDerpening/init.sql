
CREATE TABLE [Todos] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(90) NOT NULL,
    [IsTaskCompleted] bit NOT NULL,
    CONSTRAINT [PK_Todos] PRIMARY KEY ([Id])
);
GO


