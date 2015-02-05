using CloudConcerts3.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CloudConcerts3.DAL
{
    public class MusicContext3 : IdentityDbContext<ApplicationUser>
    {

        public MusicContext3()
            : base("MusicContext3")
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Listener> Listeners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            //modelBuilder.Entity<Host>().ToTable("Hosts");
        }
    }
}