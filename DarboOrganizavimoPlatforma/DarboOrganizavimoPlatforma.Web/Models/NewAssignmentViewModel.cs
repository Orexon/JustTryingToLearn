using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class NewAssignmentViewModel
    {
        [Required(ErrorMessage = "The Assignment requires a Name")]
        [StringLength(30)]
        [DisplayName("Assignment Name")]
        public string AssignmentName { get; set; }
        [Required(ErrorMessage = "The Assignment requires a Description")]
        [StringLength(200)]
        [DisplayName("Assignment Description")]
        public string AssignmentDescription { get; set; }
    }
}
