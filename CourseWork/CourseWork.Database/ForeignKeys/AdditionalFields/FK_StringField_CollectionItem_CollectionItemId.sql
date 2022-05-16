ALTER TABLE [dbo].[StringField]
	ADD CONSTRAINT [FK_StringField_CollectionItem_CollectionItemId]
	FOREIGN KEY ([CollectionItemId])
	REFERENCES [dbo].[CollectionItem] ([Id]) ON DELETE CASCADE
