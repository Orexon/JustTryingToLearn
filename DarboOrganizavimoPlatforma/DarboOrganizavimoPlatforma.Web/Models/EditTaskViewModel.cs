using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class EditTaskViewModel
    {
        [Required(ErrorMessage = "Please Enter a title")]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please describe the Task")]
        [StringLength(200, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Select Status of the Task")]
        public CompletionStatus ATaskStatus { get; set; }
    }
}
