CREATE UNIQUE INDEX [UserNameIndex]
	ON [dbo].[AspNetUsers]
	([NormalizedUserName])
	WHERE [NormalizedUserName] IS NOT NULL