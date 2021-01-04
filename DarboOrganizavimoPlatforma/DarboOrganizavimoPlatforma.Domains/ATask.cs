using System;
using System.Collections.Generic;
using System.Text;

namespace DarboOrganizavimoPlatforma.Domains
{
    public class ATask
    {
        public Guid ATaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CompletionStatus ATaskStatus { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime CompleteTime { get; set; }
        public Assignment Assignment { get; set; }
        public Guid AssignmentId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
