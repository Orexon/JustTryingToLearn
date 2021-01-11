using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class NewAssignmentTaskViewModel
    {
        [Required(ErrorMessage = "You must Choose a title for a task")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please write a description of your task")]
        public string Description { get; set; }
        public Guid AssignmentTeamId { get; set; }
        [Required(ErrorMessage = "Please choose a status")]
        public CompletionStatus ATaskStatus { get; set; }
        public Assignment Assignment { get; set; }
        public Guid AssignmentId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid AppUserId { get; set; }
        public List<ATask> AssignmentTasks { get; set; }
        public string WrittenBy { get; set; }
    }
}
