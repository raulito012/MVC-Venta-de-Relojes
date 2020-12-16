
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/15/2020 09:30:32
-- Generated from EDMX file: C:\Users\PC\Documents\Web Reloj\Catalog\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Reloj];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categoria];
GO
IF OBJECT_ID(N'[catalogoModelStoreContainer].[Buscar_Categoria]', 'U') IS NOT NULL
    DROP TABLE [catalogoModelStoreContainer].[Buscar_Categoria];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categoria'
CREATE TABLE [dbo].[Categoria] (
    [idCategoria] int IDENTITY(1,1) NOT NULL,
    [descripcion] varchar(max)  NULL
);
GO

-- Creating table 'Buscar_Categoria'
CREATE TABLE [dbo].[Buscar_Categoria] (
    [idCategoria] int IDENTITY(1,1) NOT NULL,
    [descripcion] varchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idCategoria] in table 'Categoria'
ALTER TABLE [dbo].[Categoria]
ADD CONSTRAINT [PK_Categoria]
    PRIMARY KEY CLUSTERED ([idCategoria] ASC);
GO

-- Creating primary key on [idCategoria] in table 'Buscar_Categoria'
ALTER TABLE [dbo].[Buscar_Categoria]
ADD CONSTRAINT [PK_Buscar_Categoria]
    PRIMARY KEY CLUSTERED ([idCategoria] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------