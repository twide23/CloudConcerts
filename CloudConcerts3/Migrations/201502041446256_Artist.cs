namespace CloudConcerts3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Artist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Artists", "PasswordHash", c => c.String());
            AddColumn("dbo.Artists", "SecurityStamp", c => c.String());
            AddColumn("dbo.Artists", "PhoneNumber", c => c.String());
            AddColumn("dbo.Artists", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Artists", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Artists", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Artists", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Artists", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Artists", "Id", c => c.String());
            AddColumn("dbo.Artists", "UserName", c => c.String());
            AddColumn("dbo.Hosts", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Hosts", "PasswordHash", c => c.String());
            AddColumn("dbo.Hosts", "SecurityStamp", c => c.String());
            AddColumn("dbo.Hosts", "PhoneNumber", c => c.String());
            AddColumn("dbo.Hosts", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Hosts", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Hosts", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Hosts", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Hosts", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Hosts", "Id", c => c.String());
            AddColumn("dbo.Hosts", "UserName", c => c.String());
            AddColumn("dbo.IdentityUserClaims", "Artist_ArtistID", c => c.Int());
            AddColumn("dbo.IdentityUserClaims", "Host_HostID", c => c.Int());
            AddColumn("dbo.IdentityUserLogins", "Host_HostID", c => c.Int());
            AddColumn("dbo.IdentityUserLogins", "Artist_ArtistID", c => c.Int());
            AddColumn("dbo.IdentityUserRoles", "Host_HostID", c => c.Int());
            AddColumn("dbo.IdentityUserRoles", "Artist_ArtistID", c => c.Int());
            CreateIndex("dbo.IdentityUserClaims", "Artist_ArtistID");
            CreateIndex("dbo.IdentityUserClaims", "Host_HostID");
            CreateIndex("dbo.IdentityUserLogins", "Host_HostID");
            CreateIndex("dbo.IdentityUserLogins", "Artist_ArtistID");
            CreateIndex("dbo.IdentityUserRoles", "Host_HostID");
            CreateIndex("dbo.IdentityUserRoles", "Artist_ArtistID");
            AddForeignKey("dbo.IdentityUserClaims", "Artist_ArtistID", "dbo.Artists", "ArtistID");
            AddForeignKey("dbo.IdentityUserClaims", "Host_HostID", "dbo.Hosts", "HostID");
            AddForeignKey("dbo.IdentityUserLogins", "Host_HostID", "dbo.Hosts", "HostID");
            AddForeignKey("dbo.IdentityUserRoles", "Host_HostID", "dbo.Hosts", "HostID");
            AddForeignKey("dbo.IdentityUserLogins", "Artist_ArtistID", "dbo.Artists", "ArtistID");
            AddForeignKey("dbo.IdentityUserRoles", "Artist_ArtistID", "dbo.Artists", "ArtistID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "Artist_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.IdentityUserLogins", "Artist_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.IdentityUserRoles", "Host_HostID", "dbo.Hosts");
            DropForeignKey("dbo.IdentityUserLogins", "Host_HostID", "dbo.Hosts");
            DropForeignKey("dbo.IdentityUserClaims", "Host_HostID", "dbo.Hosts");
            DropForeignKey("dbo.IdentityUserClaims", "Artist_ArtistID", "dbo.Artists");
            DropIndex("dbo.IdentityUserRoles", new[] { "Artist_ArtistID" });
            DropIndex("dbo.IdentityUserRoles", new[] { "Host_HostID" });
            DropIndex("dbo.IdentityUserLogins", new[] { "Artist_ArtistID" });
            DropIndex("dbo.IdentityUserLogins", new[] { "Host_HostID" });
            DropIndex("dbo.IdentityUserClaims", new[] { "Host_HostID" });
            DropIndex("dbo.IdentityUserClaims", new[] { "Artist_ArtistID" });
            DropColumn("dbo.IdentityUserRoles", "Artist_ArtistID");
            DropColumn("dbo.IdentityUserRoles", "Host_HostID");
            DropColumn("dbo.IdentityUserLogins", "Artist_ArtistID");
            DropColumn("dbo.IdentityUserLogins", "Host_HostID");
            DropColumn("dbo.IdentityUserClaims", "Host_HostID");
            DropColumn("dbo.IdentityUserClaims", "Artist_ArtistID");
            DropColumn("dbo.Hosts", "UserName");
            DropColumn("dbo.Hosts", "Id");
            DropColumn("dbo.Hosts", "AccessFailedCount");
            DropColumn("dbo.Hosts", "LockoutEnabled");
            DropColumn("dbo.Hosts", "LockoutEndDateUtc");
            DropColumn("dbo.Hosts", "TwoFactorEnabled");
            DropColumn("dbo.Hosts", "PhoneNumberConfirmed");
            DropColumn("dbo.Hosts", "PhoneNumber");
            DropColumn("dbo.Hosts", "SecurityStamp");
            DropColumn("dbo.Hosts", "PasswordHash");
            DropColumn("dbo.Hosts", "EmailConfirmed");
            DropColumn("dbo.Artists", "UserName");
            DropColumn("dbo.Artists", "Id");
            DropColumn("dbo.Artists", "AccessFailedCount");
            DropColumn("dbo.Artists", "LockoutEnabled");
            DropColumn("dbo.Artists", "LockoutEndDateUtc");
            DropColumn("dbo.Artists", "TwoFactorEnabled");
            DropColumn("dbo.Artists", "PhoneNumberConfirmed");
            DropColumn("dbo.Artists", "PhoneNumber");
            DropColumn("dbo.Artists", "SecurityStamp");
            DropColumn("dbo.Artists", "PasswordHash");
            DropColumn("dbo.Artists", "EmailConfirmed");
        }
    }
}
