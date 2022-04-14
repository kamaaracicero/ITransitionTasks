CREATE TABLE [dbo].[AspNetUsers]
(
	[Id] nvarchar(450) not null,
    [RegistrationDate] datetime not null,
    [LastLoginDate] datetime not null,
    [Status] int not null,
    [UserName] nvarchar(256) null,
    [NormalizedUserName] nvarchar(256) null,
    [Email] nvarchar(256) null,
    [NormalizedEmail] nvarchar(256) null,
    [EmailConfirmed] bit not null,
    [PasswordHash] nvarchar(max) null,
    [SecurityStamp] nvarchar(max) null,
    [ConcurrencyStamp] nvarchar(max) null,
    [PhoneNumber] nvarchar(max) null,
    [PhoneNumberConfirmed] bit not null,
    [TwoFactorEnabled] bit not null,
    [LockoutEnd] datetimeoffset null,
    [LockoutEnabled] bit not null,
    [AccessFailedCount] int not null,
    CONSTRAINT PK_AspNetUsers PRIMARY KEY ([Id])
)
