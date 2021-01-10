using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class NewUserViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 2)]
        [DisplayName("Member Name")]
        public string MemberName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be an email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required.")]
        [DataType(DataType.Password, ErrorMessage = "The Password must have UpperCase adn lowercase characters & Special Character")]
        [Display(Name = "Password")]
        [StringLength(30, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password Is Required.")]
        [DataType(DataType.Password, ErrorMessage = "The Password must have UpperCase adn lowercase characters & Special Character")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do no match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Choose A Role For the User")]
        public string UserRole { get; set; }

        [Required(ErrorMessage = "Please choose a company")]
        public Guid CompanyID { get; set; }

    }
}
