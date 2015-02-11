using System;
using System.Collections.Generic;
using CloudConcerts3.Models;

namespace CloudConcerts3.DAL
{
    public class MusicInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MusicContext3>
    {
        protected override void Seed(MusicContext3 context)
        {
            var genres = new List<Genre>
            {
            new Genre{Name="Alternative"},
            new Genre{Name="Blues"},
            new Genre{Name="Classical"},
            new Genre{Name="Country"},
            new Genre{Name="Electronic"},
            new Genre{Name="Folk"},
            new Genre{Name="Hip-Hop/Rap"},
            new Genre{Name="Indie"},
            new Genre{Name="Jazz"},
            new Genre{Name="Latin"},
            new Genre{Name="Metal"},
            new Genre{Name="Pop"},
            new Genre{Name="R&B/Soul"},
            new Genre{Name="Reggae"},
            new Genre{Name="Rock"}
            };
            genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();

            //var artists = new List<Artist>
            //{
            //new Artist{StageName="Cat's Meow",Description="Straight outta the alley",GenreID=1,Email="cat@aol.com"},
            //new Artist{StageName="Dog's Woof",Description="Straight outta the mud",GenreID=2,Email="dog@aol.com"},
            //new Artist{StageName="Duck's Quack",Description="Straight outta the pond",GenreID=3,Email="duck@aol.com"}
            //};
            //artists.ForEach(s => context.Artists.Add(s));
            //context.SaveChanges();

            var members = new List<Member>
            {
            new Member{FirstName="Joe",LastName="Montana",Instrument="Piano"},
            new Member{FirstName="Bill",LastName="Idaho",Instrument="Guitar"},
            new Member{FirstName="Jack",LastName="Colorado",Instrument="Bass"},
            new Member{FirstName="Jill",LastName="California",Instrument="Drums"},
            new Member{FirstName="Moe",LastName="Mississippi",Instrument="Vocals"},
            new Member{FirstName="Hillary",LastName="Florida",Instrument="Harmonica"}
            };
            members.ForEach(s => context.Members.Add(s));
            context.SaveChanges();

            //var hosts = new List<Host>
            //{
            //new Host{VenueName="Stadium", Description="LIVE MUSIC", Address="DC", Phone="456-789-1230", Website="www.stadium.com", Email="stadium@aol.com"},
            //new Host{VenueName="Jazz Hall", Description="Smooth listening", Address="Baton Rouge", Phone="789-123-4560", Website="www.jazz.com", Email="jazz@aol.com"},
            //new Host{VenueName="Backyard", Description="For a wedding", Address="Chicago", Phone="123-456-7890", Website="www.backyard.com", Email="backyard@aol.com"}
            //};
            //hosts.ForEach(s => context.Hosts.Add(s));
            //context.SaveChanges();

            var concerts = new List<Concert>
            {
            new Concert{Name="Music-palooza", Time=DateTime.Parse("6:00AM"), Date=DateTime.Parse("09-01-2015"), Description="LIVE MUSIC", TicketPrice=20, isPublic=true},
            new Concert{Name="Music-fest", Time=DateTime.Parse("10:00PM"), Date=DateTime.Parse("02-14-2015"), Description="Smooth listening", TicketPrice=10, isPublic=true},
            new Concert{Name="Brangelina", Time=DateTime.Parse("1:00PM"), Date=DateTime.Parse("05-05-2015"), Description="For a wedding", TicketPrice=0, isPublic=false}
            };
            concerts.ForEach(s => context.Concerts.Add(s));
            context.SaveChanges();

            //var listeners = new List<Listener>
            //{
            //new Listener{FirstName="Jim", LastName="Mars", City="Richmond", State="VA", Email="jim@aol.com"},
            //new Listener{FirstName="Tim", LastName="Jupiter", City="New York", State="NY", Email="tim@aol.com"},
            //new Listener{FirstName="Mike", LastName="Saturn", City="Chicago", State="IL", Email="mike@aol.com"}
            //};
            //listeners.ForEach(s => context.Listeners.Add(s));
            //context.SaveChanges();
        }
    }
}