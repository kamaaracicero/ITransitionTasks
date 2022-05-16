ALTER TABLE [dbo].[UserComment]
	ADD CONSTRAINT [FK_UserComment_AspNetUsers_UserId]
	FOREIGN KEY ([UserId])
	REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
