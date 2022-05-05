CREATE TABLE [dbo].[CollectionItemTag]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[CollectionItemId] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT pk_CollectionItemTag PRIMARY KEY([Id]),
	CONSTRAINT un_CollectionItemTag UNIQUE([CollectionItemId], [Name])
)
