ALTER TABLE [dbo].[ImageSize]
	ADD CONSTRAINT [FK_ImageSize_Collection_CollectionId]
	FOREIGN KEY ([CollectionId])
	REFERENCES [dbo].[Collection] ([Id]) ON DELETE CASCADE
