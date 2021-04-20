
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/20/2021 15:24:40
-- Generated from EDMX file: D:\C#projektek\Szoftverfejelsztok\Adatbazisos_feladatok\DBF_console_01\Oktatok.edmx
-- --------------------------------------------------

create database Oktatok

SET QUOTED_IDENTIFIER OFF;
GO
USE [Oktatok];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Tantargy_Tanar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tantargies] DROP CONSTRAINT [FK_Tantargy_Tanar];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Tanars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tanars];
GO
IF OBJECT_ID(N'[dbo].[Tantargies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tantargies];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Tanars'
CREATE TABLE [dbo].[Tanars] (
    [Id] int  NOT NULL,
    [Nev] varchar(50)  NULL,
    [SzülAdat] int  NULL,
    [E_mail] varchar(50)  NULL
);
GO

-- Creating table 'Tantargies'
CREATE TABLE [dbo].[Tantargies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tantargyak] varchar(150)  NULL,
    [Tanarid] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Tanars'
ALTER TABLE [dbo].[Tanars]
ADD CONSTRAINT [PK_Tanars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tantargies'
ALTER TABLE [dbo].[Tantargies]
ADD CONSTRAINT [PK_Tantargies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Tanarid] in table 'Tantargies'
ALTER TABLE [dbo].[Tantargies]
ADD CONSTRAINT [FK_Tantargy_Tanar]
    FOREIGN KEY ([Tanarid])
    REFERENCES [dbo].[Tanars]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tantargy_Tanar'
CREATE INDEX [IX_FK_Tantargy_Tanar]
ON [dbo].[Tantargies]
    ([Tanarid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------