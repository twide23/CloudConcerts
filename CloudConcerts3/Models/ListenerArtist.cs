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
    
    public partial class ListenerArtist
    {
        public int ListenerArtistID { get; set; }
        public string ListenerID { get; set; }
        public string ArtistID { get; set; }
    
        public virtual Artist Artist { get; set; }
        public virtual Listener Listener { get; set; }
    }
}