ALTER TABLE [dbo].[Tag]
	ADD CONSTRAINT [FK_Tag_CollectionItem_CollectionItemId]
	FOREIGN KEY ([CollectionItemId])
	REFERENCES [dbo].[CollectionItem] ([Id]) ON DELETE CASCADE
