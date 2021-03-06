﻿using DarboOrganizavimoPlatforma.Domains;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class ManagerCreateTeamViewModel
    {
        [Required]
        [StringLength(20)]
        public string TeamName { get; set; }

        [Required]
        [StringLength(200)]
        public string TeamDescription { get; set; }
    }
}
