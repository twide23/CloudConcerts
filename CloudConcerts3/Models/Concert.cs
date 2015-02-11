using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudConcerts3.Models
{
    public class Concert
    {
        public int ConcertID { get; set; }

        //[Required]
        public String Name { get; set; }

        public String HostID { get; set; }

        public virtual Host Host { get; set; }

        //[Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        //[Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public String Description { get; set; }

        //[Required]
        [Display(Name = "Ticket Price")]
        public int TicketPrice { get; set; }

        //[Required]
        [Display(Name = "Public Event?")]
        public bool isPublic { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
    }
}