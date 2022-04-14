CREATE TABLE [dbo].[AspNetUserClaims]
(
	[Id] int not null identity(1,1),
	[UserId] nvarchar(450) not null,
	[ClaimType] nvarchar(450) null,
	[ClaimValue] nvarchar(450) null,
	CONSTRAINT PK_AspNetUserClaims PRIMARY KEY ([Id])
)
