using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudConcerts3.Models
{
    public class Member
    {
        public int MemberID { get; set; }

        //[Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        //[Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        //[Required]
        public String Instrument { get; set; }
    }
}