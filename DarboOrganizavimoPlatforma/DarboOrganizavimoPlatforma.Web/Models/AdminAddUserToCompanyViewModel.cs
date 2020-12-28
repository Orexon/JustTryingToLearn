using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class AdminAddUserToCompanyViewModel
    {
        [Required(ErrorMessage = "Please Choose a Company")]
        public string CompanyID { get; set; }
        [Required(ErrorMessage = "Please Choose a User")]
        public string AppUserID { get; set; }

    }
}
