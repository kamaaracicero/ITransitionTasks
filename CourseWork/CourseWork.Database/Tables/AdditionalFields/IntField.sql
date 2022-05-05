﻿CREATE TABLE [dbo].[IntField]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[CollectionItemId] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Value] INT NOT NULL,
	CONSTRAINT pk_IntField PRIMARY KEY([Id])
)
