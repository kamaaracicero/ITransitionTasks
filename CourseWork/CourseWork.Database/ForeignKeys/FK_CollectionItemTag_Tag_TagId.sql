ALTER TABLE [dbo].[CollectionItemTag]
	ADD CONSTRAINT [FK_CollectionItemTag_Tag_TagId]
	FOREIGN KEY ([TagId])
	REFERENCES [dbo].[Tag] ([Id])
