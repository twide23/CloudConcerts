CREATE TABLE [dbo].[Artist]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY,
	[StageName] NVARCHAR(50) NULL,
	[Description] NVARCHAR(100) NULL,
	[GenreID] INT NULL,
	[ImageURL] NVARCHAR(180) NULL,
	CONSTRAINT [FK_dbo.Artist_dbo.Genre_GenreID] FOREIGN KEY ([GenreID]) 
        REFERENCES [dbo].[Genre] ([GenreID]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.Artist_dbo.AspNetUsers_Id] FOREIGN KEY ([Id]) 
        REFERENCES [dbo].[AspNetUsers] ([Id])
)
