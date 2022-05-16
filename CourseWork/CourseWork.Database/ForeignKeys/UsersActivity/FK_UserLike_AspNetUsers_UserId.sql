ALTER TABLE [dbo].[UserLike]
	ADD CONSTRAINT [FK_UserLike_AspNetUsers_UserId]
	FOREIGN KEY ([UserId])
	REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
