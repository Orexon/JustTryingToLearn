using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class UserListViewModel
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
