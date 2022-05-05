ALTER TABLE [dbo].[UserComment]
	ADD CONSTRAINT [FK_UserComment_CollectionItem_CollectionItemId]
	FOREIGN KEY ([CollectionItemId])
	REFERENCES [CollectionItem] ([Id])
