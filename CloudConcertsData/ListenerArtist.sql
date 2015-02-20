CREATE TABLE [dbo].[ListenerArtist]
(
	[ListenerArtistID] INT IDENTITY PRIMARY KEY,
	[ListenerID] NVARCHAR(128) NULL, 
	[ArtistID] NVARCHAR(128) NULL,
	CONSTRAINT [FK_dbo.ListenerArtist_dbo.Listener_Id] FOREIGN KEY ([ListenerID]) 
        REFERENCES [dbo].[Listener] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.ListenerArtist_dbo.Artist_Id] FOREIGN KEY ([ArtistID]) 
        REFERENCES [dbo].[Artist] ([Id]) ON DELETE CASCADE
)
