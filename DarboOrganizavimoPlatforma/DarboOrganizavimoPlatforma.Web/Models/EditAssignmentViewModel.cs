using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class EditAssignmentViewModel
    {

        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }
        public CompletionStatus AssingmentStatus { get; set; }
    }
}
