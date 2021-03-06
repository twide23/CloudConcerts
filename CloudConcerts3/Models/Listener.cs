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
    
    public partial class Listener
    {
        public Listener()
        {
            this.ListenerArtists = new HashSet<ListenerArtist>();
            this.ListenerGenres = new HashSet<ListenerGenre>();
        }
    
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ImageURL { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<ListenerArtist> ListenerArtists { get; set; }
        public virtual ICollection<ListenerGenre> ListenerGenres { get; set; }
    }
}
