using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Models
{
    public class CreateTaskViewModel
    {
        public string AssignmentId { get; set; }
        [Required(ErrorMessage = "Please write a title for your task")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please write a Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please write the status of your task")]
        public CompletionStatus ATaskStatus { get; set; }
    }
}
