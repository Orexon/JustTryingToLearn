using System;
using System.Collections.Generic;
using System.Text;

namespace DarboOrganizavimoPlatforma.Domains
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public ICollection<TeamUser> TeamUsers { get; set; }
        public ICollection<ProjectTeam> ProjectTeams { get; set; }
        public Company Company { get; set; }
        public DateTime CreateTime { get; set; }
    }
}