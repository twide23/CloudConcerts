CREATE TABLE [dbo].[Member]
(
	[MemberID] INT IDENTITY PRIMARY KEY, 
	[FirstName] NVARCHAR(50) NULL, 
	[LastName] NVARCHAR(50) NULL,
	[InstrumentID] INT NULL,
	[ArtistID] NVARCHAR(128) NULL,
	CONSTRAINT [FK_dbo.Member_dbo.Instrument_InstrumentID] FOREIGN KEY ([InstrumentID]) 
        REFERENCES [dbo].[Instrument] ([InstrumentID]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.Member_dbo.Artist_Id] FOREIGN KEY ([ArtistID]) 
        REFERENCES [dbo].[Artist] ([Id]) ON DELETE CASCADE
)
