using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class ChangePassAndEmailViewModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be an email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required.")]
        [DataType(DataType.Password, ErrorMessage = "The Password must have UPPERCASE and lowercase characters & Spe$ial Character")]
        [Display(Name = "Password")]
        [StringLength(30, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password Is Required.")]
        [DataType(DataType.Password, ErrorMessage = "The Password must have UpperCase adn lowercase characters & Special Character")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do no match.")]
        public string ConfirmPassword { get; set; }
    }
}
