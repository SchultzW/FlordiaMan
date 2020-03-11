USE [aspnet-FlordiaMan-7B7C68D5-8952-43D6-B70E-A58ABECE023E]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'User', N'user', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator], [Password]) VALUES (N'734213c6-dc1b-4b0e-b4d6-6fb3c91bec9e', N'Admin@admin.com', N'ADMIN@ADMIN.COM', N'Admin@admin.com', N'ADMIN@ADMIN.COM', 0, N'AQAAAAEAACcQAAAAEJJczxOTp42D72hk4DMiVbv+ACdyRAqI5LDNtKscvGhhE4jNoa7p98crWc9OjLYUTw==', N'SSFT4QZ5DTOHGI2O6ZUJTZ7ZIWV34XIL', N'd42e78ce-e455-428c-840c-7f0efd3d6669', NULL, 0, 0, NULL, 1, 0, NULL, N'AppUser', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator], [Password]) VALUES (N'cfda1a04-962f-42f3-875c-cf63f113a060', N'User@user.com', N'USER@USER.COM', N'User@user.com', N'USER@USER.COM', 0, N'AQAAAAEAACcQAAAAENQkil5LR0IBCcr7Z5su9apqlQFuUk1zkgT6f6oeKD5yV9GafUMlNHgiV5EW+7Z+vQ==', N'HWLUUGN5FVFIW3Q7FV5F5KAV2P423D7T', N'25eaedd6-568c-46e7-a736-bf272da6d748', NULL, 0, 0, NULL, 1, 0, NULL, N'AppUser', NULL)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'734213c6-dc1b-4b0e-b4d6-6fb3c91bec9e', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cfda1a04-962f-42f3-875c-cf63f113a060', N'2')
