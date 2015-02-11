using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CloudConcerts3.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "Type of Account")]
        public string Type { get; set; }

        /*********** Artist form ************/
        [Display(Name = "Stage Name")]
        public string ArtistStageName { get; set; }

        [Display(Name = "Description")]
        public string ArtistDescription { get; set; }

        //[Required]
        public int ArtistGenreID { get; set; }

        [Display(Name = "Genre")]
        public virtual Genre ArtistGenre { get; set; }
        /*********** END Artist form ************/

        /*********** Host form ************/
        [Display(Name = "Venue Name")]
        public string HostVenueName { get; set; }

        [Display(Name = "Description")]
        public string HostDescription { get; set; }

        [Display(Name = "Address")]
        public string HostAddress { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string HostPhone { get; set; }

        [Url]
        [Display(Name = "Website")]
        public string HostWebsite { get; set; }
        /*********** END Host form ************/

        /*********** Listener form ************/
        [Display(Name = "First Name")]
        public string ListenerFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string ListenerLastName { get; set; }

        [Display(Name = "City")]
        public string ListenerCity { get; set; }

        [Display(Name = "State")]
        public string ListenerState { get; set; }
        /*********** END Listener form ************/

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
