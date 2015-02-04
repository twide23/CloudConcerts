namespace CloudConcerts3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        StageName = c.String(),
                        Description = c.String(),
                        GenreID = c.Int(nullable: false),
                        Email = c.String(),
                        Listener_ListenerID = c.Int(),
                    })
                .PrimaryKey(t => t.ArtistID)
                .ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
                .ForeignKey("dbo.Listeners", t => t.Listener_ListenerID)
                .Index(t => t.GenreID)
                .Index(t => t.Listener_ListenerID);
            
            CreateTable(
                "dbo.Concerts",
                c => new
                    {
                        ConcertID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HostID = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        TicketPrice = c.Int(nullable: false),
                        isPublic = c.Boolean(nullable: false),
                        Listener_ListenerID = c.Int(),
                    })
                .PrimaryKey(t => t.ConcertID)
                .ForeignKey("dbo.Hosts", t => t.HostID, cascadeDelete: true)
                .ForeignKey("dbo.Listeners", t => t.Listener_ListenerID)
                .Index(t => t.HostID)
                .Index(t => t.Listener_ListenerID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Concert_ConcertID = c.Int(),
                        Listener_ListenerID = c.Int(),
                    })
                .PrimaryKey(t => t.GenreID)
                .ForeignKey("dbo.Concerts", t => t.Concert_ConcertID)
                .ForeignKey("dbo.Listeners", t => t.Listener_ListenerID)
                .Index(t => t.Concert_ConcertID)
                .Index(t => t.Listener_ListenerID);
            
            CreateTable(
                "dbo.Hosts",
                c => new
                    {
                        HostID = c.Int(nullable: false, identity: true),
                        VenueName = c.String(),
                        Description = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Website = c.String(),
                        Email = c.String(),
                        Listener_ListenerID = c.Int(),
                    })
                .PrimaryKey(t => t.HostID)
                .ForeignKey("dbo.Listeners", t => t.Listener_ListenerID)
                .Index(t => t.Listener_ListenerID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Instrument = c.String(),
                        Artist_ArtistID = c.Int(),
                    })
                .PrimaryKey(t => t.MemberID)
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistID)
                .Index(t => t.Artist_ArtistID);
            
            CreateTable(
                "dbo.Listeners",
                c => new
                    {
                        ListenerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ListenerID);
            
            CreateTable(
                "dbo.ConcertArtists",
                c => new
                    {
                        Concert_ConcertID = c.Int(nullable: false),
                        Artist_ArtistID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Concert_ConcertID, t.Artist_ArtistID })
                .ForeignKey("dbo.Concerts", t => t.Concert_ConcertID, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistID, cascadeDelete: true)
                .Index(t => t.Concert_ConcertID)
                .Index(t => t.Artist_ArtistID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hosts", "Listener_ListenerID", "dbo.Listeners");
            DropForeignKey("dbo.Genres", "Listener_ListenerID", "dbo.Listeners");
            DropForeignKey("dbo.Artists", "Listener_ListenerID", "dbo.Listeners");
            DropForeignKey("dbo.Concerts", "Listener_ListenerID", "dbo.Listeners");
            DropForeignKey("dbo.Members", "Artist_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.Artists", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.Concerts", "HostID", "dbo.Hosts");
            DropForeignKey("dbo.Genres", "Concert_ConcertID", "dbo.Concerts");
            DropForeignKey("dbo.ConcertArtists", "Artist_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.ConcertArtists", "Concert_ConcertID", "dbo.Concerts");
            DropIndex("dbo.ConcertArtists", new[] { "Artist_ArtistID" });
            DropIndex("dbo.ConcertArtists", new[] { "Concert_ConcertID" });
            DropIndex("dbo.Members", new[] { "Artist_ArtistID" });
            DropIndex("dbo.Hosts", new[] { "Listener_ListenerID" });
            DropIndex("dbo.Genres", new[] { "Listener_ListenerID" });
            DropIndex("dbo.Genres", new[] { "Concert_ConcertID" });
            DropIndex("dbo.Concerts", new[] { "Listener_ListenerID" });
            DropIndex("dbo.Concerts", new[] { "HostID" });
            DropIndex("dbo.Artists", new[] { "Listener_ListenerID" });
            DropIndex("dbo.Artists", new[] { "GenreID" });
            DropTable("dbo.ConcertArtists");
            DropTable("dbo.Listeners");
            DropTable("dbo.Members");
            DropTable("dbo.Hosts");
            DropTable("dbo.Genres");
            DropTable("dbo.Concerts");
            DropTable("dbo.Artists");
        }
    }
}
