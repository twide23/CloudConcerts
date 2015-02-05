using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudConcerts3.Models
{
    [Table("Hosts")]
    public class Host : ApplicationUser
    {
        [Display(Name = "Venue")]
        public String VenueName { get; set; }

        public String Description { get; set; }

        public String Address { get; set; }

        public String Phone { get; set; }

        public String Website { get; set; }

        //public virtual ICollection<Concert> Concerts { get; set; }

        //public String Email { get; set; }
    }
}