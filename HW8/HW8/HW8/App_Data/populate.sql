--POPULATE ARTISTS TABLE WITH GIVEN VALUES
INSERT INTO [dbo].[Artists](FirstName,LastName,BirthDate,BirthCity,BirthCountry) VALUES ('M.C.','Escher','06/17/1898','Leeuwarden','Netherlands');
INSERT INTO [dbo].[Artists](FirstName,LastName,BirthDate,BirthCity,BirthCountry) VALUES ('Leonardo','Da Vinci','05/02/1519','Vinci','Italy');
INSERT INTO [dbo].[Artists](FirstName,LastName,BirthDate,BirthCity,BirthCountry) VALUES ('Hatip Mehmed','Efendi','11/18/1680','Unknown','Unknown');
INSERT INTO [dbo].[Artists](FirstName,LastName,BirthDate,BirthCity,BirthCountry) VALUES ('Salvador','Dali','05/11/1904','Figueres','Spain');

--POPULATE ARTWORK TABLE WITH GIVEN VALUES
INSERT INTO [dbo].[Artworks] (Title,ArtistID) VALUES('Circle Limit III', 1);
INSERT INTO [dbo].[Artworks] (Title,ArtistID) VALUES('Twon Tree', 1);
INSERT INTO [dbo].[Artworks] (Title,ArtistID) VALUES('Mona Lisa', 2);
INSERT INTO [dbo].[Artworks] (Title,ArtistID) VALUES('The Vitruvian Man', 2);
INSERT INTO [dbo].[Artworks] (Title,ArtistID) VALUES('Ebru', 3);
INSERT INTO [dbo].[Artworks] (Title,ArtistID) VALUES('Honey Is Sweeter Than Blood', 4);

--POPULATE GENRES TABLE WITH GIVEN VALUES
INSERT INTO [dbo].[Genres](Name)VALUES('Tesselation');
INSERT INTO [dbo].[Genres](Name)VALUES('Surrealism');
INSERT INTO [dbo].[Genres](Name)VALUES('Portrait');
INSERT INTO [dbo].[Genres](Name)VALUES('Renaissance');

--POPULATE CLASSIFICATIONS TABLE WITH GIVEN VALUES
INSERT INTO [dbo].[Classifications](ArtworkID,GenreID)VALUES(1,1);
INSERT INTO [dbo].[Classifications](ArtworkID,GenreID)VALUES(2,1);
INSERT INTO [dbo].[Classifications](ArtworkID,GenreID)VALUES(2,2);
INSERT INTO [dbo].[Classifications](ArtworkID,GenreID)VALUES(3,3);
INSERT INTO [dbo].[Classifications](ArtworkID,GenreID)VALUES(3,4);
INSERT INTO [dbo].[Classifications](ArtworkID,GenreID)VALUES(4,4);
INSERT INTO [dbo].[Classifications](ArtworkID,GenreID)VALUES(5,1);
INSERT INTO [dbo].[Classifications](ArtworkID,GenreID)VALUES(6,2);