CREATE TABLE [dbo].[AspNetUserTokens]
(
	[UserId] nvarchar(450) not null,
	[LoginProvider] nvarchar(450) not null,
	[Name] nvarchar(450) not null,
	[Value] nvarchar(450) null,
	CONSTRAINT PK_AspNetUserTokens PRIMARY KEY ([UserId], [LoginProvider], [Name])
)
