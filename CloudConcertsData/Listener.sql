CREATE TABLE [dbo].[Listener]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
	[FirstName] NVARCHAR(50) NULL,
	[LastName] NVARCHAR(100) NULL,
	[City] NVARCHAR(100) NULL,
	[State] NVARCHAR(20) NULL,
	[ImageURL] NVARCHAR(180) NULL,
	CONSTRAINT [FK_dbo.Listener_dbo.AspNetUsers_Id] FOREIGN KEY ([Id]) 
        REFERENCES [dbo].[AspNetUsers] ([Id])
)
