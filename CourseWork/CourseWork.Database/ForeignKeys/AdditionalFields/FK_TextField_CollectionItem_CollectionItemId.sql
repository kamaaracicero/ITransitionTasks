ALTER TABLE [dbo].[TextField]
	ADD CONSTRAINT [FK_TextField_CollectionItem_CollectionItemId]
	FOREIGN KEY ([CollectionItemId])
	REFERENCES [dbo].[CollectionItem] ([Id])
