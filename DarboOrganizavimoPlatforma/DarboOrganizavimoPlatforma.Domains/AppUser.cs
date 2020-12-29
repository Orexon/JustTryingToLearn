using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DarboOrganizavimoPlatforma.Domains
{
    public class AppUser : IdentityUser<Guid>
    {
        public string MemberName { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<TeamUser> TeamUsers { get; set; }
        public ICollection<Project> CompanyTeamMembers { get; set; }
        public DateTime JoinDateTime { get; set; }
        
    }
}

