using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudConcerts3.Models
{
    [Table("Artists")]
    public class Artist : ApplicationUser
    {
        [Display(Name = "Stage Name")]
        public String StageName { get; set; }

        public String Description { get; set; }

        public int GenreID { get; set; }

        public virtual Genre Genre { get; set; }

        //public virtual ICollection<Member> Members { get; set; }

        //public virtual ICollection<Concert> Concerts { get; set; }

        //public String Email { get; set; }
    }
}