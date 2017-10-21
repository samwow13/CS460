CREATE DATABASE [HW5_DB]
 CONTAINMENT = NONE
 ON  PRIMARY
(NAME = N'HW5_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HW5_DB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON
(NAME = N'HW5_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HW5_DB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

USE [HW5_DB]
GO

----DROP TABLES----
IF OBJECT_ID('dbo.Requests', 'R') IS NOT NULL
	DROP TABLE [dbo].[Requests];
GO

----CREATE TABLE----
CREATE TABLE [dbo].[Requests]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
		[ODL] INT NOT NULL,
		[DoB] NVARCHAR(20) NOT NULL,
		[FullName] NVARCHAR(100) NOT NULL,
		[StreetAddress] NVARCHAR(100) NOT NULL,
		[City] NVARCHAR(50) NOT NULL,
		[States] NVARCHAR(20) NOT NULL,
		[ZipCode] NVARCHAR(20) NOT NULL,
		[County] NVARCHAR(50) NOT NULL,
		CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([ID] ASC)
);

----FILL TABLE----
INSERT INTO [dbo].[Requests] (ODL, DoB, FullName, StreetAddress, City, States, ZipCode, County)
VALUES ('11222', '04071985', 'Sam Wetzel', '7265 Harmony Road', 'Sheridan', 'OR', '97378', 'Polk'),
		('44222', '09031985', 'John Plough', '1024 Center Street', 'Mcminnville', 'OR', '97127', 'Yamhill'),
		('23222', '03201975', 'Clair Warnicke', '3327 Willamina Road', 'Willamina', 'OR', '97375', 'Polk'),
		('42999', '11151985', 'Steve Williams', '2021 Sheridan Road', 'Sheridan', 'OR', '97378', 'Yamhill'),
		('74252', '04101985', 'David Schug', '1100 16th street', 'Lafayette', 'OR', '97128', 'Yamhill'); 