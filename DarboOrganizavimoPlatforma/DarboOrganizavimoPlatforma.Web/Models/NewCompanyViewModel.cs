using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class NewCompanyViewModel
    {
        [Required]
        [StringLength(30)]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [DisplayName("Company Description")]
        [StringLength(200)]
        [Required]
        public string CompanyDescription { get; set; }
        public DateTime CreateTime { get; set; }
        [Required(ErrorMessage = "The Member Size plan is required")]
        public CompanyMemberSize CompanyMemberSize { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 2)]
        [DisplayName("Member Name")]
        public string MemberName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do no match.")]
        public string ConfirmPassword { get; set; }
    }
}
