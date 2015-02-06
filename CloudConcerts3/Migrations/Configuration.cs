namespace CloudConcerts3.Migrations
{
    using CloudConcerts3.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<CloudConcerts3.DAL.MusicContext3>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CloudConcerts3.DAL.MusicContext3";
        }

        protected override void Seed(CloudConcerts3.DAL.MusicContext3 context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
