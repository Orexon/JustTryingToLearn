﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class ManageUserRolesViewModel
    {
        public string UserId { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}
