ALTER TABLE [dbo].[CollectionItem]
	ADD CONSTRAINT [FK_CollectionItem_Collection_CollectionId]
	FOREIGN KEY ([CollectionId])
	REFERENCES [dbo].[Collection] ([Id])
