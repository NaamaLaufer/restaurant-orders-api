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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260621104811_InitialCreate'
)
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260621104811_InitialCreate'
)
BEGIN
    CREATE TABLE [Orders] (
        [Id] int NOT NULL IDENTITY,
        [OrderDate] datetime2 NOT NULL,
        [CustomerName] nvarchar(max) NOT NULL,
        [TotalAmount] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260621104811_InitialCreate'
)
BEGIN
    CREATE TABLE [Dishes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_Dishes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Dishes_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260621104811_InitialCreate'
)
BEGIN
    CREATE TABLE [OrderDishes] (
        [OrderId] int NOT NULL,
        [DishId] int NOT NULL,
        [Quantity] int NOT NULL,
        CONSTRAINT [PK_OrderDishes] PRIMARY KEY ([OrderId], [DishId]),
        CONSTRAINT [FK_OrderDishes_Dishes_DishId] FOREIGN KEY ([DishId]) REFERENCES [Dishes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderDishes_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260621104811_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Dishes_CategoryId] ON [Dishes] ([CategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260621104811_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_OrderDishes_DishId] ON [OrderDishes] ([DishId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260621104811_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260621104811_InitialCreate', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260621130329_SyncModels'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260621130329_SyncModels', N'8.0.0');
END;
GO

COMMIT;
GO

