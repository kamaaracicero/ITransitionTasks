CREATE TABLE [dbo].[AspNetRoles]
(
	[Id] nvarchar(450) not null,
    [Name] nvarchar(256) null,
    [NormalizedName] nvarchar(256) null,
    [ConcurrencyStamp] nvarchar(max) null,
    CONSTRAINT PK_AspNetRoles PRIMARY KEY ([Id])
)
