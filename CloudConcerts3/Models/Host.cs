using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudConcerts3.Models
{
    [Table("Hosts")]
    public class Host : ApplicationUser
    {
        //[Required]
        [Display(Name = "Venue")]
        public String VenueName { get; set; }

        public String Description { get; set; }

        //[Required]
        public String Address { get; set; }

        //[Required]
        public String Phone { get; set; }

        public String Website { get; set; }

        //public virtual ICollection<Concert> Concerts { get; set; }
    }
}