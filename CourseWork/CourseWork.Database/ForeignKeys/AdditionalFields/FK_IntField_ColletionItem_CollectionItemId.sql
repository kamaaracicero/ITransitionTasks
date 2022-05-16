ALTER TABLE [dbo].[IntField]
	ADD CONSTRAINT [FK_IntField_ColletionItem_CollectionItemId]
	FOREIGN KEY ([CollectionItemId])
	REFERENCES [dbo].[CollectionItem] ([Id]) ON DELETE CASCADE
