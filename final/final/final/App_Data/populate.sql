-- ########### Buyers ###########
INSERT INTO [dbo].[Buyers](FullName)VALUES('Jane Stone');
INSERT INTO [dbo].[Buyers](FullName)VALUES('Tom McMasters');
INSERT INTO [dbo].[Buyers](FullName)VALUES('Otto Vanderwall');


-- ########### Sellers ###########
INSERT INTO [dbo].[Sellers](FullName)VALUES('Gayle Hardy');
INSERT INTO [dbo].[Sellers](FullName)VALUES('Lyle Banks');
INSERT INTO [dbo].[Sellers](FullName)VALUES('Pearl Greene');


-- ########### Items ###########
INSERT INTO [dbo].[Items](FullName,Description,SellersID)VALUES('Abraham Lincoln Hammer','A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln',3);
INSERT INTO [dbo].[Items](FullName,Description,SellersID)VALUES('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927',1);
INSERT INTO [dbo].[Items](FullName,Description,SellersID)VALUES('Bob Dylan Love Poems','Five versions of an original unpublished, handwritten, love poem by Bob Dylan',2);



-- ########### Bids ###########
INSERT INTO [dbo].[Bids](ItemID,Price,BuyerID,TimeStamp)VALUES(1001,250000,3,'12/04/2017 09:04:22');
INSERT INTO [dbo].[Bids](ItemID,Price,BuyerID,TimeStamp)VALUES(1003,95000 ,1,'12/04/2017 08:44:03');

