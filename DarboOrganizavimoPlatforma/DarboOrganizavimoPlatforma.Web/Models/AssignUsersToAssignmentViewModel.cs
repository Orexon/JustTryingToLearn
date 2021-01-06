using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class AssignUsersToAssignmentViewModel
    {
        [Required(ErrorMessage = "Please Choose a User")]
        public string AppUserId { get; set; }
        public Guid CurrentTeamId { get; set; }
        public Guid CurrentAssignmentId { get; set; }
        public List<UserListViewModel> AssignmentMemberListViewModel { get; set; }


    }
}
