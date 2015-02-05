using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudConcerts3.Models
{
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