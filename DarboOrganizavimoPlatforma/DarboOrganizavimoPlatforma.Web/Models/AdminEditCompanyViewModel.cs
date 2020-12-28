using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class AdminEditCompanyViewModel
    {
        [Required]
        [StringLength(30)]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [DisplayName("Company Description")]
        [StringLength(200)]
        [Required]
        public string CompanyDescription { get; set; }
        [Required(ErrorMessage = "The Member Size plan is required")]
        public CompanyMemberSize CompanyMemberSize { get; set; }
    }
}
