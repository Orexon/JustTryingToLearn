using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class AddUserToTeamViewModel
    {
        [Required(ErrorMessage = "Please Choose a User")]
        public string AppUserId { get; set; }
        public Guid TeamId { get; set; }
        public List<UserListViewModel> TeamUserListViewModel { get; set; }
    }
}
