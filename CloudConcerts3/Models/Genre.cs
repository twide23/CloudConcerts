using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudConcerts3.Models
{
    public class Genre
    {
        public int GenreID { get; set; }

        [Display(Name = "Genre")]
        public String Name { get; set; }
    }
}