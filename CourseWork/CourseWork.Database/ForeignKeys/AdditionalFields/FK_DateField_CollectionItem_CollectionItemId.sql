ALTER TABLE [dbo].[DateField]
	ADD CONSTRAINT [FK_DateField_CollectionItem_CollectionItemId]
	FOREIGN KEY ([CollectionItemId])
	REFERENCES [dbo].[CollectionItem] ([Id])
