CREATE TABLE [dbo].[CollectionTheme]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Theme] NVARCHAR(100) NOT NULL,
	CONSTRAINT pk_CollectionTheme PRIMARY KEY([Id]),
	CONSTRAINT un_COllectionTheme UNIQUE([Theme])
)
