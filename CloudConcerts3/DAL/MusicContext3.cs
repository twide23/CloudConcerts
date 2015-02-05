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

            //modelBuilder.Entity<IdentityUserLogin>().ToTable("IdentityUserLogin");
            //modelBuilder.Entity<IdentityRole>().ToTable("IdentityRole");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("IdentityUserRole");
            //modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<Host>().ToTable("Hosts");
            modelBuilder.Entity<Artist>().ToTable("Artists");
            modelBuilder.Entity<Listener>().ToTable("Listeners");

        }
    }
}