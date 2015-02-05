namespace CloudConcerts3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbstuff4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Concert_ConcertID = c.Int(),
                    })
                .PrimaryKey(t => t.GenreID)
                .ForeignKey("dbo.Concerts", t => t.Concert_ConcertID)
                .Index(t => t.Concert_ConcertID);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                        Host_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ConcertID)
                .ForeignKey("dbo.Hosts", t => t.Host_Id)
                .Index(t => t.Host_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Instrument = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Concert_ConcertID = c.Int(),
                        StageName = c.String(),
                        Description = c.String(),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Concerts", t => t.Concert_ConcertID)
                .ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Concert_ConcertID)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Hosts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        VenueName = c.String(),
                        Description = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Listeners",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        City = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Listeners", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hosts", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Artists", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.Artists", "Concert_ConcertID", "dbo.Concerts");
            DropForeignKey("dbo.Artists", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Concerts", "Host_Id", "dbo.Hosts");
            DropForeignKey("dbo.Genres", "Concert_ConcertID", "dbo.Concerts");
            DropIndex("dbo.Listeners", new[] { "Id" });
            DropIndex("dbo.Hosts", new[] { "Id" });
            DropIndex("dbo.Artists", new[] { "GenreID" });
            DropIndex("dbo.Artists", new[] { "Concert_ConcertID" });
            DropIndex("dbo.Artists", new[] { "Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Concerts", new[] { "Host_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Genres", new[] { "Concert_ConcertID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.Listeners");
            DropTable("dbo.Hosts");
            DropTable("dbo.Artists");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Members");
            DropTable("dbo.Concerts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Genres");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
        }
    }
}
