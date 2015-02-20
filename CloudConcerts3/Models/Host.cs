//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CloudConcerts3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Host
    {
        public Host()
        {
            this.Concerts = new HashSet<Concert>();
            this.Gigs = new HashSet<Gig>();
        }
    
        public string Id { get; set; }
        public string VenueName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string ImageURL { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<Concert> Concerts { get; set; }
        public virtual ICollection<Gig> Gigs { get; set; }
    }
}
