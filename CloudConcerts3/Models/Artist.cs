using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudConcerts3.Models
{
    [Table("Artists")]
    public class Artist : ApplicationUser
    {
        //[Required]
        [Display(Name = "Stage Name")]
        [StringLength(50)]
        public String StageName { get; set; }

        public String Description { get; set; }

        //[Required]
        public int GenreID { get; set; }

        public virtual Genre Genre { get; set; }

        //[Required]
        //public virtual ICollection<Member> Members { get; set; }

        //public virtual ICollection<Concert> Concerts { get; set; }
    }
}