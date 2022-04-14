CREATE TABLE [dbo].[AspNetRoleClaims]
(
	[Id] int not null identity(1,1),
	[RoleId] nvarchar(450) not null,
	[ClaimType] nvarchar(max) null,
	[ClaimValue] nvarchar(max) null,
	CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY ([Id])
)
