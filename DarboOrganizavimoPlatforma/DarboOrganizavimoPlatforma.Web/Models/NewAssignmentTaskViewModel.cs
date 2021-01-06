using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class NewAssignmentTaskViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AssignmentTeamId { get; set; }
        public CompletionStatus ATaskStatus { get; set; }
        public Assignment Assignment { get; set; }
        public Guid AssignmentId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid AppUserId { get; set; }
        public List<ATask> AssignmentTasks { get; set; }
        public string WrittenBy { get; set; }
    }
}
