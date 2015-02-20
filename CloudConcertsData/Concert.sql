CREATE TABLE [dbo].[Concert]
(
	[ConcertID] INT IDENTITY PRIMARY KEY, 
	[Name] NVARCHAR(50) NOT NULL, 
	[Description] NVARCHAR(100) NULL,
	[HostID] NVARCHAR(128) NOT NULL,
	[StartTime] DATETIME NOT NULL,
	[EndTime] DATETIME NOT NULL,
	[TicketPrice] MONEY NOT NULL,
	[isPublic] BIT NOT NULL,
	CONSTRAINT [FK_dbo.Concert_dbo.Host_Id] FOREIGN KEY ([HostID]) 
        REFERENCES [dbo].[Host] ([Id]) ON DELETE CASCADE
)
