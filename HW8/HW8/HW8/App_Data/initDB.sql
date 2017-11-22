﻿
--ARTIST TABLE
CREATE TABLE [dbo.Artists] (
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[BirthDate] DATETIME2 NOT NULL,
	[BirthCity] NVARCHAR NOT NULL,
	[BirthCountry] NVARCHAR NOT NULL,
	CONSTRAINT [PK_dbo.Artists] PRIMARY KEY CLUSTERED ([ID] ASC)
);

--ARTWORK TABLE
CREATE TABLE [dbo.ArtWorks] (
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Title] NVARCHAR(100) NOT NULL,
	[ArtistID] INT NOT NULL,
	CONSTRAINT [PK_dbo.Artworks] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Arworks_dbo_ArtistID] FOREIGN KEY ([ArtistID]) REFERENCES [dbo].[Artists] ([ID])
);

--GENRES TABLE
CREATE TABLE [dbo.Genres] (
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_dbo.Genres] PRIMARY KEY CLUSTERED ([ID] ASC)
);

--CLASSIFICATIONS TABLE
CREATE TABLE [dbo.Classifications] (
	[ID] INT IDENTITY (1,1) NOT NULL,
	[ArtWorkID] INT NOT NULL,
	[GenreID]INT NOT NULL,
	CONSTRAINT [PK_dbo.Classifications] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Classifications_dbo.ArtWorkID] FOREIGN KEY ([ArtWorkID]) REFERENCES [dbo].[ArtWorks] ([ID]),
	CONSTRAINT [FK_dbo.Classifications_dbo.GenreID] FOREIGN KEY ([GenreID]) REFERENCES [dbo].[Genres] ([ID])
);