CREATE TABLE [dbo].[CollectionItem]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[CollectionId] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT pk_CollectionItem PRIMARY KEY([Id]),
)
