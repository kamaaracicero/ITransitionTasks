CREATE TABLE [dbo].[AspNetUserRoles]
(
	[UserId] NVARCHAR(450) NOT NULL,
	[RoleId] NVARCHAR(450) NOT NULL,
	CONSTRAINT pk_AspNetUserRoles PRIMARY KEY ([UserId], [RoleId])
)
