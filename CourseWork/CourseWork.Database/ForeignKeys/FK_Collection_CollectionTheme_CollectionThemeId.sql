ALTER TABLE [dbo].[Collection]
	ADD CONSTRAINT [FK_Collection_CollectionTheme_CollectionThemeId]
	FOREIGN KEY ([CollectionThemeId])
	REFERENCES [dbo].[CollectionTheme] ([Id])
