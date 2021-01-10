using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class EditUserProfileViewModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please Enter a MemberName")]
        [StringLength(25, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 2)]
        public string MemberName { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Please Enter A valid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 2)]
        public string UserName { get; set; }

        [StringLength(30, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 1)]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 1)]
        public string LastName { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Location { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 1)]
        public string Position { get; set; }
        [StringLength(450, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 1)]
        public string Notes { get; set; }

        public byte[] ProfilePicture { get; set; }
    }
}
