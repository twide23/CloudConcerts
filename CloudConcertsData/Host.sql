CREATE TABLE [dbo].[Host]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
	[VenueName] NVARCHAR(50) NULL,
	[Description] NVARCHAR(100) NULL,
	[Address] NVARCHAR(100) NULL,
	[Phone] NVARCHAR(20) NULL,
	[Website] NVARCHAR(100) NULL,
	[ImageURL] NVARCHAR(180) NULL,
	CONSTRAINT [FK_dbo.Host_dbo.AspNetUsers_Id] FOREIGN KEY ([Id]) 
        REFERENCES [dbo].[AspNetUsers] ([Id])
)
