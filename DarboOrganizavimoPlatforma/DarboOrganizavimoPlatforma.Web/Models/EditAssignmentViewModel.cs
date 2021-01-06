using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class EditAssignmentViewModel
    {
        public Guid AssignmentId { get; set; }
        public Guid TeamId { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }
        public CompletionStatus AssignmentStatus { get; set; }
    }
}
