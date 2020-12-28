using System;
using System.Collections.Generic;
using System.Text;

namespace DarboOrganizavimoPlatforma.Domains
{
    public class Project
    {
        public Project()
        {
            ProjectTeams = new List<Team>();
        }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public ICollection<Team> ProjectTeams { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
