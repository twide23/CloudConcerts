using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudConcerts3.Models
{
    public class Host : IdentityUser
    {
        [Key]
        public int HostID { get; set; }

        [Display(Name = "Venue")]
        public String VenueName { get; set; }

        public String Description { get; set; }

        public String Address { get; set; }

        public String Phone { get; set; }

        public String Website { get; set; }

        public virtual ICollection<Concert> Concerts { get; set; }

        //public String Email { get; set; }
    }
}