ALTER TABLE [dbo].[UserLike]
	ADD CONSTRAINT [FK_UserLike_CollectionItem_CollectionItemId]
	FOREIGN KEY ([CollectionItemId])
	REFERENCES [dbo].[CollectionItem] ([Id]) ON DELETE CASCADE
