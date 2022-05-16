CREATE TABLE [dbo].[ImageSize]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[CollectionId] INT NOT NULL,
	[Height] INT NOT NULL,
	[Width] INT NOT NULL,
	CONSTRAINT pk_ImageSize PRIMARY KEY([Id])
)
