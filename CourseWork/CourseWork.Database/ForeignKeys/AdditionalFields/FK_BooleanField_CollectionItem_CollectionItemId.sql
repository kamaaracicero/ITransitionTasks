ALTER TABLE [dbo].[BooleanField]
	ADD CONSTRAINT [FK_BooleanField_CollectionItem_CollectionItemId]
	FOREIGN KEY ([CollectionItemId])
	REFERENCES [dbo].[CollectionItem] ([Id]) ON DELETE CASCADE
