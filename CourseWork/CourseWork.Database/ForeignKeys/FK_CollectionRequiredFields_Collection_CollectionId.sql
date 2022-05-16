ALTER TABLE [dbo].[CollectionRequiredFields]
	ADD CONSTRAINT [FK_CollectionRequiredFields_Collection_CollectionId]
	FOREIGN KEY ([CollectionId])
	REFERENCES [dbo].[Collection] ([Id]) ON DELETE CASCADE
