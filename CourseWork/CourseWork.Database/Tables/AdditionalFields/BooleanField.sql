CREATE TABLE [dbo].[BooleanField]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[CollectionItemId] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Value] BIT NOT NULL,
	CONSTRAINT pk_BooleanField PRIMARY KEY([Id])
)
