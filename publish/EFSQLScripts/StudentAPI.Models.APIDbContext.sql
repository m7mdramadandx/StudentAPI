IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221113044839_Initial Create')
BEGIN
    CREATE TABLE [Students] (
        [StudentID] int NOT NULL IDENTITY,
        [Name] nvarchar(250) NOT NULL,
        [ContactNumber] int NOT NULL,
        [Age] int NOT NULL,
        CONSTRAINT [PK_Students] PRIMARY KEY ([StudentID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221113044839_Initial Create')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221113044839_Initial Create', N'6.0.10');
END;
GO

COMMIT;
GO

