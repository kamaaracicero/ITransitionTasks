ALTER TABLE [dbo].[CollectionItemTag]
	ADD CONSTRAINT [FK_CollectionItemTag_CollectionItem_CollectionItemId]
	FOREIGN KEY ([CollectionItemId])
	REFERENCES [dbo].[CollectionItem] ([Id])
