using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DarboOrganizavimoPlatforma.Domains
{
    public class Company
    {
        public Company()
        {
            CompanyProjects = new List<Project>();
            Teams = new List<Team>();
        }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<Team> Teams { get; set; }
        public List<Project> CompanyProjects { get; set; }
        public DateTime CreateTime { get; set; }
        public CompanyMemberSize CompanyMemberSize { get; set; }
    }
}