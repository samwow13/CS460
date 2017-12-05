-- ########### Buyers ###########
CREATE TABLE [dbo].[Buyers]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FullName] NVARCHAR (100) NOT NULL,	
	CONSTRAINT [PK_dbo.Buyers] PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- ########### Sellers ###########
CREATE TABLE [dbo].[Sellers]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FullName] NVARCHAR (100) NOT NULL,
	CONSTRAINT [PK_dbo.Sellers] PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- ########### Items ###########
CREATE TABLE [dbo].[Items]
(
	[ID] INT IDENTITY (1001,1) NOT NULL,	
	[FullName] NVARCHAR (100) NOT NULL,
	[Description] NVARCHAR (200) NOT NULL,
	[SellersID] INT NOT NULL,
	CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Items_dbo.SellersID] FOREIGN KEY ([SellersID]) REFERENCES [dbo].[Sellers] ([ID])
);

-- ########### Bids ###########
CREATE TABLE [dbo].[Bids]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[ItemID] INT NOT NULL,
	[BuyerID] INT NOT NULL,
	[Price] INT NOT NULL,
	[TimeStamp] DATETIME2 NOT NULL,
	CONSTRAINT [PK_dbo.Bids] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Bids_dbo.ItemID] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items] ([ID]),
	CONSTRAINT [FK_dbo.Bids_dbo.BuyerID] FOREIGN KEY ([BuyerID]) REFERENCES [dbo].[Buyers] ([ID])
);