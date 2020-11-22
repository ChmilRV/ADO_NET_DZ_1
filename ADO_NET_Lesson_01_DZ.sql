use [master];
go
create database [Library];
go
use [Library];
go
CREATE TABLE [dbo].[Authors]
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL
)
GO
CREATE TABLE [dbo].[Books]
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	AuthorId INT NOT NULL,
	FOREIGN KEY (AuthorId) REFERENCES AUTHORS (Id),
	Title VARCHAR(100) NOT NULL,
	PRICE INT,
	PAGES INT
)
GO
INSERT INTO Authors (FirstName, LastName) VALUES
	('Isaac', 'Asimov'),
	('Roger', 'Zelazny');
GO
INSERT INTO Books (AuthorId, Title, Price, Pages) VALUES
	(1, 'Pebble in the Sky', 250, 220),
	(1, 'The Stars, Like Dust', 340, 280),
	(1, 'The Currents of Space', 180, 200),
	(2, 'Nine Princes in Amber', 440, 320),
	(2, 'The Guns of Avalon', 390, 410),
	(2, 'Sign of the Unicorn', 330, 380);
GO
