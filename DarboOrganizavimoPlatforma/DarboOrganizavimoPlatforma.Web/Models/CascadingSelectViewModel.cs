using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class CascadingSelectViewModel
    {
        public CascadingSelectViewModel()
        {
            this.Companies = new List<SelectListItem>();
            this.Teams = new List<SelectListItem>();
        }

        public List<SelectListItem> Companies { get; set; }
        public List<SelectListItem> Teams { get; set; }

        public Guid CompanyId { get; set; }
        public Guid TeamId { get; set; }
    }
}
