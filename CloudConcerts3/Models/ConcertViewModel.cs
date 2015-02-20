using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudConcerts3.Models
{
    public class ConcertViewModel
    {
        public int ConcertID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HostName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TicketPrice { get; set; }
        public bool isPublic { get; set; }
    }
}