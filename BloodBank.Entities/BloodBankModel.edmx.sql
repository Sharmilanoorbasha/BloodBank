
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/10/2022 14:11:19
-- Generated from EDMX file: C:\Training\BloodBank\BloodBank.Entities\BloodBankModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BloodBank];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserBloodReq]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BloodReqs] DROP CONSTRAINT [FK_UserBloodReq];
GO
IF OBJECT_ID(N'[dbo].[FK_HospitalSlot]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Slots] DROP CONSTRAINT [FK_HospitalSlot];
GO
IF OBJECT_ID(N'[dbo].[FK_SlotBloodReq]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BloodReqs] DROP CONSTRAINT [FK_SlotBloodReq];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Hospitals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hospitals];
GO
IF OBJECT_ID(N'[dbo].[Slots]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Slots];
GO
IF OBJECT_ID(N'[dbo].[BloodReqs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BloodReqs];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserName] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Age] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [ContactNumber] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Weight] nvarchar(max)  NOT NULL,
    [BloodGroup] nvarchar(max)  NOT NULL,
    [Role] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Hospitals'
CREATE TABLE [dbo].[Hospitals] (
    [HospitalName] int IDENTITY(1,1) NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Area] nvarchar(max)  NOT NULL,
    [Pincode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Slots'
CREATE TABLE [dbo].[Slots] (
    [SlotId] uniqueidentifier  NOT NULL,
    [SlotTime] datetime  NOT NULL,
    [HospitalHospitalName] int  NOT NULL
);
GO

-- Creating table 'BloodReqs'
CREATE TABLE [dbo].[BloodReqs] (
    [ReqId] uniqueidentifier  NOT NULL,
    [PatientName] nvarchar(max)  NOT NULL,
    [PatientPhoneNo] nvarchar(max)  NOT NULL,
    [BloodGroup] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [UserUserName] int  NOT NULL,
    [SlotSlotId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserName] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserName] ASC);
GO

-- Creating primary key on [HospitalName] in table 'Hospitals'
ALTER TABLE [dbo].[Hospitals]
ADD CONSTRAINT [PK_Hospitals]
    PRIMARY KEY CLUSTERED ([HospitalName] ASC);
GO

-- Creating primary key on [SlotId] in table 'Slots'
ALTER TABLE [dbo].[Slots]
ADD CONSTRAINT [PK_Slots]
    PRIMARY KEY CLUSTERED ([SlotId] ASC);
GO

-- Creating primary key on [ReqId] in table 'BloodReqs'
ALTER TABLE [dbo].[BloodReqs]
ADD CONSTRAINT [PK_BloodReqs]
    PRIMARY KEY CLUSTERED ([ReqId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserUserName] in table 'BloodReqs'
ALTER TABLE [dbo].[BloodReqs]
ADD CONSTRAINT [FK_UserBloodReq]
    FOREIGN KEY ([UserUserName])
    REFERENCES [dbo].[Users]
        ([UserName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBloodReq'
CREATE INDEX [IX_FK_UserBloodReq]
ON [dbo].[BloodReqs]
    ([UserUserName]);
GO

-- Creating foreign key on [HospitalHospitalName] in table 'Slots'
ALTER TABLE [dbo].[Slots]
ADD CONSTRAINT [FK_HospitalSlot]
    FOREIGN KEY ([HospitalHospitalName])
    REFERENCES [dbo].[Hospitals]
        ([HospitalName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HospitalSlot'
CREATE INDEX [IX_FK_HospitalSlot]
ON [dbo].[Slots]
    ([HospitalHospitalName]);
GO

-- Creating foreign key on [SlotSlotId] in table 'BloodReqs'
ALTER TABLE [dbo].[BloodReqs]
ADD CONSTRAINT [FK_SlotBloodReq]
    FOREIGN KEY ([SlotSlotId])
    REFERENCES [dbo].[Slots]
        ([SlotId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SlotBloodReq'
CREATE INDEX [IX_FK_SlotBloodReq]
ON [dbo].[BloodReqs]
    ([SlotSlotId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------