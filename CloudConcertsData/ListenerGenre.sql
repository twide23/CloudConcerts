CREATE TABLE [dbo].[ListenerGenre]
(
	[ListenerGenreID] INT IDENTITY PRIMARY KEY,
	[ListenerID] NVARCHAR(128) NULL, 
	[GenreID] INT NULL,
	CONSTRAINT [FK_dbo.ListenerGenre_dbo.Listener_Id] FOREIGN KEY ([ListenerID]) 
        REFERENCES [dbo].[Listener] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.ListenerGenre_dbo.Genre_GenreID] FOREIGN KEY ([GenreID]) 
        REFERENCES [dbo].[Genre] ([GenreID]) ON DELETE CASCADE
)
