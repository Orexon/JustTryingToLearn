using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class UserTaskViewModel
    {
        public List<ATask> UserTasks { get; set; }
        public List<ATask> UserWrittenTasks { get; set; }
    }
}
