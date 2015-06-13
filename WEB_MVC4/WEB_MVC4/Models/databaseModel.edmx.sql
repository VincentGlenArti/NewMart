
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/12/2015 21:34:40
-- Generated from EDMX file: C:\Projects\WEB_MVC4\WEB_MVC4\Models\databaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WEBDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductSet] DROP CONSTRAINT [FK_ProductCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductManufacturer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductSet] DROP CONSTRAINT [FK_ProductManufacturer];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderProductsProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderProductsSet] DROP CONSTRAINT [FK_OrderProductsProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderProductsOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderProductsSet] DROP CONSTRAINT [FK_OrderProductsOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_OrderLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_StockProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockSet] DROP CONSTRAINT [FK_StockProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_StockLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockSet] DROP CONSTRAINT [FK_StockLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategorySet] DROP CONSTRAINT [FK_CategoryCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductDiscount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiscountSet] DROP CONSTRAINT [FK_ProductDiscount];
GO
IF OBJECT_ID(N'[dbo].[FK_UserOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_UserOrder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[dbo].[CategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategorySet];
GO
IF OBJECT_ID(N'[dbo].[ManufacturerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManufacturerSet];
GO
IF OBJECT_ID(N'[dbo].[DiscountSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DiscountSet];
GO
IF OBJECT_ID(N'[dbo].[OrderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderSet];
GO
IF OBJECT_ID(N'[dbo].[OrderProductsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderProductsSet];
GO
IF OBJECT_ID(N'[dbo].[LocationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationSet];
GO
IF OBJECT_ID(N'[dbo].[StockSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StockSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Info] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [CategoryID] smallint  NOT NULL,
    [ManufacturerID] smallint  NOT NULL,
    [Picture] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [ID] smallint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CategoryID] smallint  NOT NULL
);
GO

-- Creating table 'ManufacturerSet'
CREATE TABLE [dbo].[ManufacturerSet] (
    [ID] smallint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DiscountSet'
CREATE TABLE [dbo].[DiscountSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DiscountUnit] nvarchar(max)  NOT NULL,
    [DiscountVal] nvarchar(max)  NOT NULL,
    [ProductID] int  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [Cost] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [SubmitTime] nvarchar(max)  NOT NULL,
    [ArrivalTime] nvarchar(max)  NOT NULL,
    [DoneTime] nvarchar(max)  NOT NULL,
    [LocationID] smallint  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'OrderProductsSet'
CREATE TABLE [dbo].[OrderProductsSet] (
    [Ammount] nvarchar(max)  NOT NULL,
    [ProductID] int  NOT NULL,
    [OrderID] bigint  NOT NULL
);
GO

-- Creating table 'LocationSet'
CREATE TABLE [dbo].[LocationSet] (
    [ID] smallint IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StockSet'
CREATE TABLE [dbo].[StockSet] (
    [Ammount] nvarchar(max)  NOT NULL,
    [ProductID] int  NOT NULL,
    [LocationID] smallint  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CartSet'
CREATE TABLE [dbo].[CartSet] (
    [ID] nvarchar(max)  NOT NULL,
    [UserID] nvarchar(max)  NOT NULL,
    [UpdateDate] nvarchar(max)  NOT NULL,
    [User_UserId] int  NOT NULL
);
GO

-- Creating table 'CartProductsSet'
CREATE TABLE [dbo].[CartProductsSet] (
    [CartID] nvarchar(max)  NOT NULL,
    [ProductID] int  NOT NULL,
    [Ammount] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ManufacturerSet'
ALTER TABLE [dbo].[ManufacturerSet]
ADD CONSTRAINT [PK_ManufacturerSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DiscountSet'
ALTER TABLE [dbo].[DiscountSet]
ADD CONSTRAINT [PK_DiscountSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ProductID], [OrderID] in table 'OrderProductsSet'
ALTER TABLE [dbo].[OrderProductsSet]
ADD CONSTRAINT [PK_OrderProductsSet]
    PRIMARY KEY CLUSTERED ([ProductID], [OrderID] ASC);
GO

-- Creating primary key on [ID] in table 'LocationSet'
ALTER TABLE [dbo].[LocationSet]
ADD CONSTRAINT [PK_LocationSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ProductID], [LocationID] in table 'StockSet'
ALTER TABLE [dbo].[StockSet]
ADD CONSTRAINT [PK_StockSet]
    PRIMARY KEY CLUSTERED ([ProductID], [LocationID] ASC);
GO

-- Creating primary key on [UserId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [ID] in table 'CartSet'
ALTER TABLE [dbo].[CartSet]
ADD CONSTRAINT [PK_CartSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [CartID], [ProductID] in table 'CartProductsSet'
ALTER TABLE [dbo].[CartProductsSet]
ADD CONSTRAINT [PK_CartProductsSet]
    PRIMARY KEY CLUSTERED ([CartID], [ProductID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryID] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_ProductCategory]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[CategorySet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCategory'
CREATE INDEX [IX_FK_ProductCategory]
ON [dbo].[ProductSet]
    ([CategoryID]);
GO

-- Creating foreign key on [ManufacturerID] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_ProductManufacturer]
    FOREIGN KEY ([ManufacturerID])
    REFERENCES [dbo].[ManufacturerSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductManufacturer'
CREATE INDEX [IX_FK_ProductManufacturer]
ON [dbo].[ProductSet]
    ([ManufacturerID]);
GO

-- Creating foreign key on [ProductID] in table 'OrderProductsSet'
ALTER TABLE [dbo].[OrderProductsSet]
ADD CONSTRAINT [FK_OrderProductsProduct]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[ProductSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [OrderID] in table 'OrderProductsSet'
ALTER TABLE [dbo].[OrderProductsSet]
ADD CONSTRAINT [FK_OrderProductsOrder]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[OrderSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderProductsOrder'
CREATE INDEX [IX_FK_OrderProductsOrder]
ON [dbo].[OrderProductsSet]
    ([OrderID]);
GO

-- Creating foreign key on [LocationID] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_OrderLocation]
    FOREIGN KEY ([LocationID])
    REFERENCES [dbo].[LocationSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderLocation'
CREATE INDEX [IX_FK_OrderLocation]
ON [dbo].[OrderSet]
    ([LocationID]);
GO

-- Creating foreign key on [ProductID] in table 'StockSet'
ALTER TABLE [dbo].[StockSet]
ADD CONSTRAINT [FK_StockProduct]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[ProductSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LocationID] in table 'StockSet'
ALTER TABLE [dbo].[StockSet]
ADD CONSTRAINT [FK_StockLocation]
    FOREIGN KEY ([LocationID])
    REFERENCES [dbo].[LocationSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StockLocation'
CREATE INDEX [IX_FK_StockLocation]
ON [dbo].[StockSet]
    ([LocationID]);
GO

-- Creating foreign key on [CategoryID] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [FK_CategoryCategory]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[CategorySet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryCategory'
CREATE INDEX [IX_FK_CategoryCategory]
ON [dbo].[CategorySet]
    ([CategoryID]);
GO

-- Creating foreign key on [ProductID] in table 'DiscountSet'
ALTER TABLE [dbo].[DiscountSet]
ADD CONSTRAINT [FK_ProductDiscount]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[ProductSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductDiscount'
CREATE INDEX [IX_FK_ProductDiscount]
ON [dbo].[DiscountSet]
    ([ProductID]);
GO

-- Creating foreign key on [UserId] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_UserOrder]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserOrder'
CREATE INDEX [IX_FK_UserOrder]
ON [dbo].[OrderSet]
    ([UserId]);
GO

-- Creating foreign key on [CartID] in table 'CartProductsSet'
ALTER TABLE [dbo].[CartProductsSet]
ADD CONSTRAINT [FK_CartProductsCart]
    FOREIGN KEY ([CartID])
    REFERENCES [dbo].[CartSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [User_UserId] in table 'CartSet'
ALTER TABLE [dbo].[CartSet]
ADD CONSTRAINT [FK_UserCart]
    FOREIGN KEY ([User_UserId])
    REFERENCES [dbo].[UserSet]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCart'
CREATE INDEX [IX_FK_UserCart]
ON [dbo].[CartSet]
    ([User_UserId]);
GO

-- Creating foreign key on [ProductID] in table 'CartProductsSet'
ALTER TABLE [dbo].[CartProductsSet]
ADD CONSTRAINT [FK_ProductCartProducts]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[ProductSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCartProducts'
CREATE INDEX [IX_FK_ProductCartProducts]
ON [dbo].[CartProductsSet]
    ([ProductID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------