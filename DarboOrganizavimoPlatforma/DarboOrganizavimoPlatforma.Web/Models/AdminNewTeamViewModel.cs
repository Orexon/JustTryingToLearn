using DarboOrganizavimoPlatforma.Domains;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class AdminNewTeamViewModel
    {
        [Required]
        [StringLength(20)]
        public string TeamName { get; set; }

        [Required]
        [StringLength(200)]
        public string TeamDescription { get; set; }

        [Required(ErrorMessage = "Please Choose a Company")]
        public string CompanyID { get; set; }
    }
}
