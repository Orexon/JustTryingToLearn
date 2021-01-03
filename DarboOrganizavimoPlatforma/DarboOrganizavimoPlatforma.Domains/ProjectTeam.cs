using System;
using System.Collections.Generic;
using System.Text;

namespace DarboOrganizavimoPlatforma.Domains
{
    public class ProjectTeam
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
