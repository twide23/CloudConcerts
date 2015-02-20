CREATE TABLE [dbo].[ArtistGig]
(
	[ArtistGigID] INT IDENTITY PRIMARY KEY,
	[ArtistID] NVARCHAR(128) NULL, 
	[GigID] INT NULL,
	CONSTRAINT [FK_dbo.ArtistGig_dbo.Artist_Id] FOREIGN KEY ([ArtistID]) 
        REFERENCES [dbo].[Artist] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.ArtistGig_dbo.Gig_GigID] FOREIGN KEY ([GigID]) 
        REFERENCES [dbo].[Gig] ([GigID]) ON DELETE CASCADE
)
