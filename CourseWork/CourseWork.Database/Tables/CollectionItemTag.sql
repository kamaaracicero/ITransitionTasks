CREATE TABLE [dbo].[CollectionItemTag]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[CollectionItemId] INT NOT NULL,
	[TagId] INT NOT NULL,
	CONSTRAINT pk_CollectionItemTag PRIMARY KEY([Id])
)
