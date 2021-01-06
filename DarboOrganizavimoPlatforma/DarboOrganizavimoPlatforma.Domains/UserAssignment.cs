using System;
using System.Collections.Generic;
using System.Text;

namespace DarboOrganizavimoPlatforma.Domains
{
    public class UserAssignment
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Guid AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }
}
