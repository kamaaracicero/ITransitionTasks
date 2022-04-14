CREATE TABLE [dbo].[AspNetUserRoles]
(
	[UserId] nvarchar(450) not null,
	[RoleId] nvarchar(450) not null,
	CONSTRAINT PK_AspNetUserRoles PRIMARY KEY ([UserId], [RoleId])
)
