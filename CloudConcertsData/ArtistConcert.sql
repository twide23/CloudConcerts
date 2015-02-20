CREATE TABLE [dbo].[ArtistConcert]
(
	[ArtistConcertID] INT IDENTITY PRIMARY KEY,
	[ArtistID] NVARCHAR(128) NULL, 
	[ConcertID] INT NULL,
	CONSTRAINT [FK_dbo.ArtistConcert_dbo.Artist_Id] FOREIGN KEY ([ArtistID]) 
        REFERENCES [dbo].[Artist] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.ArtistConcert_dbo.Concert_ConcertID] FOREIGN KEY ([ConcertID]) 
        REFERENCES [dbo].[Concert] ([ConcertID]) ON DELETE CASCADE
)
