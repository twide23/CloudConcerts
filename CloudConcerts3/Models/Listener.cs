using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudConcerts3.Models
{
    [Table("Listeners")]
    public class Listener : ApplicationUser
    {
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        //public virtual ICollection<Artist> FavArtists { get; set; }

        //public virtual ICollection<Genre> FavGenres { get; set; }

        //public virtual ICollection<Host> FavHosts { get; set; }

        //public virtual ICollection<Concert> Concerts { get; set; }

        //public String Email { get; set; }
    }
}