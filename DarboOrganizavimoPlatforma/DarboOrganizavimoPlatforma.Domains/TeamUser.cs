using System;

namespace DarboOrganizavimoPlatforma.Domains
{
    public class TeamUser
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}