CREATE TABLE [dbo].[GigGenre]
(
	[GigGenreID] INT IDENTITY PRIMARY KEY,
	[GigID] INT NULL, 
	[GenreID] INT NULL,
	CONSTRAINT [FK_dbo.GigGenre_dbo.Gig_GigID] FOREIGN KEY ([GigID]) 
        REFERENCES [dbo].[Gig] ([GigID]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.GigGenre_dbo.Genre_GenreID] FOREIGN KEY ([GenreID]) 
        REFERENCES [dbo].[Genre] ([GenreID]) ON DELETE CASCADE
)
