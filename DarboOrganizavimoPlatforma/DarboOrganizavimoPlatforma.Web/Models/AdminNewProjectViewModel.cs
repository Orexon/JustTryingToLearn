using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class AdminNewProjectViewModel
    {
        [Required]
        [StringLength(20)]
        public string ProjectName { get; set; }

        [Required]
        [StringLength(200)]
        public string ProjectDescription { get; set; }

        [Required(ErrorMessage = "Please Choose a Company")]
        public string CompanyID { get; set; }
    }
}
