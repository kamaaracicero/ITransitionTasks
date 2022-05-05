﻿CREATE TABLE [dbo].[StringField]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[CollectionItemId] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Value] NVARCHAR(300) NOT NULL,
	CONSTRAINT pk_StringField PRIMARY KEY([Id])
)
