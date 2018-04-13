
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/13/2018 11:24:12
-- Generated from EDMX file: D:\Coding\RTES_WEB_Project\RTESWebProjectMVC\Models\rtesEntities1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [rtes];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_client_client]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[client] DROP CONSTRAINT [FK_client_client];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[abstract_user]', 'U') IS NOT NULL
    DROP TABLE [dbo].[abstract_user];
GO
IF OBJECT_ID(N'[dbo].[appraiser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[appraiser];
GO
IF OBJECT_ID(N'[dbo].[appraiserReport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[appraiserReport];
GO
IF OBJECT_ID(N'[dbo].[appraiserTaskList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[appraiserTaskList];
GO
IF OBJECT_ID(N'[dbo].[client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[client];
GO
IF OBJECT_ID(N'[dbo].[emergencyReport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[emergencyReport];
GO
IF OBJECT_ID(N'[dbo].[estimationForm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[estimationForm];
GO
IF OBJECT_ID(N'[dbo].[image]', 'U') IS NOT NULL
    DROP TABLE [dbo].[image];
GO
IF OBJECT_ID(N'[dbo].[messagesTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[messagesTable];
GO
IF OBJECT_ID(N'[dbo].[taskList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[taskList];
GO
IF OBJECT_ID(N'[dbo].[third_party]', 'U') IS NOT NULL
    DROP TABLE [dbo].[third_party];
GO
IF OBJECT_ID(N'[dbo].[towingReportForm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[towingReportForm];
GO
IF OBJECT_ID(N'[dbo].[truckDriver]', 'U') IS NOT NULL
    DROP TABLE [dbo].[truckDriver];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'abstract_user'
CREATE TABLE [dbo].[abstract_user] (
    [id] int  NOT NULL,
    [name] varchar(50)  NULL,
    [familyName] varchar(50)  NULL,
    [email] varchar(50)  NULL,
    [address] varchar(50)  NULL,
    [gender] nchar(10)  NULL,
    [status] tinyint  NULL,
    [password] varchar(50)  NULL,
    [role] varchar(50)  NULL,
    [company] varchar(50)  NULL,
    [userPhoneNumber] varchar(50)  NULL
);
GO

-- Creating table 'clients'
CREATE TABLE [dbo].[clients] (
    [abstractUserId] int  NOT NULL,
    [insuranceCompanyName] varchar(50)  NULL,
    [licensePlate] int  NULL,
    [carCategory] varchar(50)  NULL,
    [carModel] varchar(50)  NULL,
    [originalTowingDestination] varchar(50)  NULL,
    [insurancePolicyNum] int  NULL,
    [clientDrivingLicenseNumber] int  NULL,
    [policyEndDate] varchar(50)  NULL,
    [updates] varchar(max)  NULL,
    [emergencyReportId] int  NULL,
    [carOwnerName] varchar(50)  NULL,
    [carOwnerId] int  NULL,
    [carLicenseNumber] int  NULL,
    [insuranceAgentName] varchar(50)  NULL,
    [insuranceAgentPhoneNum] int  NULL,
    [carManufactureYear] varchar(50)  NULL
);
GO

-- Creating table 'emergencyReports'
CREATE TABLE [dbo].[emergencyReports] (
    [reportID] int  NOT NULL,
    [clientAbstractUserId] int  NOT NULL,
    [caseCaseId] int  NULL,
    [date] varchar(50)  NULL,
    [hour] varchar(50)  NULL,
    [location] varchar(max)  NULL,
    [towing_destination] varchar(max)  NULL,
    [accident_witness_name] varchar(50)  NULL,
    [accident_witness_phone] varchar(50)  NULL,
    [comments] varchar(max)  NULL,
    [callForTowing] bit  NOT NULL,
    [status] int  NULL,
    [OperatorComment] varchar(max)  NULL,
    [Latitude] varchar(max)  NULL,
    [Longitude] varchar(max)  NULL,
    [latDest] varchar(max)  NULL,
    [lngDest] varchar(max)  NULL
);
GO

-- Creating table 'messagesTables'
CREATE TABLE [dbo].[messagesTables] (
    [msgNum] int  NOT NULL,
    [userID] int  NULL,
    [content] varchar(max)  NULL,
    [date] varchar(50)  NULL
);
GO

-- Creating table 'third_party'
CREATE TABLE [dbo].[third_party] (
    [emergencyReportId] int  NOT NULL,
    [driverName] varchar(50)  NULL,
    [driverId] varchar(50)  NOT NULL,
    [carOwnerName] varchar(50)  NULL,
    [carOwnerId] varchar(50)  NULL,
    [licensePlateNumber] varchar(50)  NULL,
    [carCategory] varchar(50)  NULL,
    [carModel] varchar(50)  NULL,
    [carColor] varchar(50)  NULL,
    [drivingLicenseNumber] varchar(50)  NULL,
    [insuranceCompanyName] varchar(50)  NULL,
    [insurancePolicyNumber] varchar(50)  NULL,
    [address] varchar(50)  NULL,
    [phoneNumber] varchar(50)  NOT NULL,
    [insuranceAgentName] varchar(50)  NULL,
    [insuranceAgentPhone] varchar(50)  NULL,
    [yearOfManufacture] int  NULL
);
GO

-- Creating table 'images'
CREATE TABLE [dbo].[images] (
    [id] int  NULL,
    [picture] varbinary(max)  NULL,
    [imgid] int  NOT NULL
);
GO

-- Creating table 'estimationForms'
CREATE TABLE [dbo].[estimationForms] (
    [reportID] int  NOT NULL,
    [appraiserUserID] int  NULL,
    [estimationText] varchar(max)  NULL,
    [date] varchar(max)  NULL
);
GO

-- Creating table 'truckDrivers'
CREATE TABLE [dbo].[truckDrivers] (
    [abstractUserId] int  NOT NULL,
    [cargo] int  NULL,
    [availability] bit  NULL,
    [workStatus] bit  NULL,
    [location] varchar(max)  NULL,
    [TasksCounter] int  NULL,
    [Latitude] varchar(max)  NULL,
    [Longitude] varchar(max)  NULL,
    [priority1] int  NULL,
    [priority2] int  NULL,
    [priority3] int  NULL,
    [priority4] int  NULL,
    [priority5] int  NULL,
    [priority6] int  NULL,
    [priority1Role] varchar(max)  NULL,
    [priority2Role] varchar(max)  NULL,
    [priority3Role] varchar(max)  NULL,
    [priority4Role] varchar(max)  NULL,
    [priority5Role] varchar(max)  NULL,
    [priority6Role] varchar(max)  NULL
);
GO

-- Creating table 'towingReportForms'
CREATE TABLE [dbo].[towingReportForms] (
    [reportID] int  NOT NULL,
    [driverUserID] int  NULL,
    [arrivalTime] varchar(max)  NULL,
    [date] varchar(max)  NULL,
    [towingDestinationLocation] varchar(max)  NULL,
    [comments] varchar(max)  NULL
);
GO

-- Creating table 'taskLists'
CREATE TABLE [dbo].[taskLists] (
    [truckDriverId] int  NULL,
    [reportId] int  NULL,
    [taskId] int  NOT NULL,
    [status] int  NULL
);
GO

-- Creating table 'appraisers'
CREATE TABLE [dbo].[appraisers] (
    [appraiserID] int  NOT NULL,
    [taskCount] int  NULL,
    [Latitude] varchar(max)  NULL,
    [Longitude] varchar(max)  NULL,
    [region] varchar(50)  NULL
);
GO

-- Creating table 'appraiserReports'
CREATE TABLE [dbo].[appraiserReports] (
    [appraiserReportId] int  NOT NULL,
    [emergencyReportID] int  NULL,
    [appraiserId] int  NULL,
    [summaryDamage1] varchar(max)  NULL,
    [amount1] int  NULL,
    [picture1] varbinary(max)  NULL,
    [summaryDamage2] varchar(max)  NULL,
    [amount2] int  NULL,
    [picture2] varbinary(max)  NULL,
    [sumTotal] int  NULL,
    [comments] varchar(max)  NULL,
    [summaryDamage3] varchar(max)  NULL,
    [amount3] int  NULL,
    [picture3] varbinary(max)  NULL,
    [summaryDamage4] varchar(max)  NULL,
    [amount4] int  NULL,
    [picture4] varbinary(max)  NULL,
    [summaryDamage5] varchar(max)  NULL,
    [amount5] int  NULL,
    [picture5] varbinary(max)  NULL
);
GO

-- Creating table 'appraiserTaskLists'
CREATE TABLE [dbo].[appraiserTaskLists] (
    [appraID] int  NOT NULL,
    [taskID] int  NOT NULL,
    [location] varchar(max)  NULL,
    [status] int  NULL,
    [clientName] varchar(50)  NULL,
    [clientPhone] varchar(50)  NULL,
    [date] varchar(50)  NULL,
    [reportId] int  NULL,
    [hour] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'abstract_user'
ALTER TABLE [dbo].[abstract_user]
ADD CONSTRAINT [PK_abstract_user]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [abstractUserId] in table 'clients'
ALTER TABLE [dbo].[clients]
ADD CONSTRAINT [PK_clients]
    PRIMARY KEY CLUSTERED ([abstractUserId] ASC);
GO

-- Creating primary key on [reportID] in table 'emergencyReports'
ALTER TABLE [dbo].[emergencyReports]
ADD CONSTRAINT [PK_emergencyReports]
    PRIMARY KEY CLUSTERED ([reportID] ASC);
GO

-- Creating primary key on [msgNum] in table 'messagesTables'
ALTER TABLE [dbo].[messagesTables]
ADD CONSTRAINT [PK_messagesTables]
    PRIMARY KEY CLUSTERED ([msgNum] ASC);
GO

-- Creating primary key on [emergencyReportId] in table 'third_party'
ALTER TABLE [dbo].[third_party]
ADD CONSTRAINT [PK_third_party]
    PRIMARY KEY CLUSTERED ([emergencyReportId] ASC);
GO

-- Creating primary key on [imgid] in table 'images'
ALTER TABLE [dbo].[images]
ADD CONSTRAINT [PK_images]
    PRIMARY KEY CLUSTERED ([imgid] ASC);
GO

-- Creating primary key on [reportID] in table 'estimationForms'
ALTER TABLE [dbo].[estimationForms]
ADD CONSTRAINT [PK_estimationForms]
    PRIMARY KEY CLUSTERED ([reportID] ASC);
GO

-- Creating primary key on [abstractUserId] in table 'truckDrivers'
ALTER TABLE [dbo].[truckDrivers]
ADD CONSTRAINT [PK_truckDrivers]
    PRIMARY KEY CLUSTERED ([abstractUserId] ASC);
GO

-- Creating primary key on [reportID] in table 'towingReportForms'
ALTER TABLE [dbo].[towingReportForms]
ADD CONSTRAINT [PK_towingReportForms]
    PRIMARY KEY CLUSTERED ([reportID] ASC);
GO

-- Creating primary key on [taskId] in table 'taskLists'
ALTER TABLE [dbo].[taskLists]
ADD CONSTRAINT [PK_taskLists]
    PRIMARY KEY CLUSTERED ([taskId] ASC);
GO

-- Creating primary key on [appraiserID] in table 'appraisers'
ALTER TABLE [dbo].[appraisers]
ADD CONSTRAINT [PK_appraisers]
    PRIMARY KEY CLUSTERED ([appraiserID] ASC);
GO

-- Creating primary key on [appraiserReportId] in table 'appraiserReports'
ALTER TABLE [dbo].[appraiserReports]
ADD CONSTRAINT [PK_appraiserReports]
    PRIMARY KEY CLUSTERED ([appraiserReportId] ASC);
GO

-- Creating primary key on [taskID] in table 'appraiserTaskLists'
ALTER TABLE [dbo].[appraiserTaskLists]
ADD CONSTRAINT [PK_appraiserTaskLists]
    PRIMARY KEY CLUSTERED ([taskID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [abstractUserId] in table 'clients'
ALTER TABLE [dbo].[clients]
ADD CONSTRAINT [FK_client_client]
    FOREIGN KEY ([abstractUserId])
    REFERENCES [dbo].[clients]
        ([abstractUserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------