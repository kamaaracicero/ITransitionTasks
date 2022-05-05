CREATE TABLE [dbo].[Collection]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Title] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,
	[CollectionThemeId] INT NOT NULL,
	[Image] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT pk_Collection PRIMARY KEY([Id])
)
