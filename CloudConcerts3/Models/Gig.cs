using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudConcerts3.Models
{
    public class Gig
    {
        public int GigID { get; set; }

        //[Required]
        public String Name { get; set; }

        public String HostID { get; set; }

        public virtual Host Host { get; set; }

        //[Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }

        //[Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public String Description { get; set; }

        //[Required]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public double Compensation { get; set; }

        //[Required]
        [Display(Name = "Public Event?")]
        public bool isPublic { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
    }
}