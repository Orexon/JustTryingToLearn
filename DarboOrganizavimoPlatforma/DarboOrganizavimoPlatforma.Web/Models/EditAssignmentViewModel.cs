using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class EditAssignmentViewModel
    {
        public Guid AssignmentId { get; set; }
        public Guid TeamId { get; set; }
        [Required]
        public string AssignmentName { get; set; }
        [Required]
        public string AssignmentDescription { get; set; }
        [Required]
        public CompletionStatus AssignmentStatus { get; set; }
    }
}
