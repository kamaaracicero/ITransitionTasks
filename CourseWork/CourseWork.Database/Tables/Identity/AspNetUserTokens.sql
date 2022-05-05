CREATE TABLE [dbo].[AspNetUserTokens]
(
	[UserId] NVARCHAR(450) NOT NULL,
	[LoginProvider] NVARCHAR(450) NOT NULL,
	[Name] NVARCHAR(450) NOT NULL,
	[Value] NVARCHAR(450) NULL,
	CONSTRAINT PK_AspNetUserTokens PRIMARY KEY ([UserId], [LoginProvider], [Name])
)
