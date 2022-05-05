CREATE TABLE [dbo].[AspNetRoleClaims]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[RoleId] NVARCHAR(450) NOT NULL,
	[ClaimType] NVARCHAR(max) NULL,
	[ClaimValue] NVARCHAR(max) NULL,
	CONSTRAINT pk_AspNetRoleClaims PRIMARY KEY ([Id])
)
