using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class AddTeamToProjectViewModel
    {
        [Required(ErrorMessage = "Please Choose a Team")]
        public string TeamId { get; set; }

        public List<Team> ProjectTeams { get; set; }
    }
}
