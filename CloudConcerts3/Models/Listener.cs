using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudConcerts3.Models
{
    [Table("Listeners")]
    public class Listener : ApplicationUser
    {
        //[Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        //[Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        //[Required]
        public String City { get; set; }

        //[Required]
        
        public String State { get; set; }

        //public virtual ICollection<Artist> FavArtists { get; set; }

        //public virtual ICollection<Genre> FavGenres { get; set; }

        //public virtual ICollection<Host> FavHosts { get; set; }

        //public virtual ICollection<Concert> Concerts { get; set; }
    }
}