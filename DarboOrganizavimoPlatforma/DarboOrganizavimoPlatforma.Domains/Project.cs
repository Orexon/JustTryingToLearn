using System;
using System.Collections.Generic;
using System.Text;

namespace DarboOrganizavimoPlatforma.Domains
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public Company Company  { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public ICollection<ProjectTeam> ProjectTeams { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
