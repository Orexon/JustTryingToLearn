using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{
    public class ATaskController : Controller
    {

        //All Tasks. Admin Only. 

        //All Assignment Tasks.(list of Task with the Html view of Task description etc..)

        //User Specific Tasks

        //Create Task.
        //Change Task status.
        //Delete Task.

        //Set To In Progress - appuser name to list or smth.

        //Select Assignment. View assignment Tasks. -> Pass Assignment id. -> Completed//ToDo//In Progress buttons at the top to open task views
        //Create Task at the top of the page. [Title Input field, Description Input field, Select Status Input field]. Create button. 
        //List of Current Tasks -> Number of a Task -> Their Status ->   Edit.Delete.More Detail. -> 


        private readonly UserManager<AppUser> _userManager;
        private readonly IAssignmentService _assignmentService;
        private readonly ITaskService _taskService;

        public ATaskController(UserManager<AppUser> userManager, IAssignmentService assignmentService, ITaskService taskService)
        {
            _userManager = userManager;
            _assignmentService = assignmentService;
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateAssignmentTask(Guid assignmentId)
        {
            AppUser user = _userManager.GetUserAsync(User).Result;

            var newviewmodel = new NewAssignmentTaskViewModel
            {
                AssignmentTeamId = await _assignmentService.GetTeamByAssignmentId(assignmentId),
                AppUserId = user.Id,
                AssignmentId = assignmentId,
                Assignment = await _assignmentService.GetAssignmentById(assignmentId), //etc
                AssignmentTasks = await _taskService.GetAssignmentTasks(assignmentId),
            };
            return View(newviewmodel);
        }     

        [HttpPost]
        public async Task<IActionResult> CreateAssignmentTask(NewAssignmentTaskViewModel model, Guid AssignmentId)
        {
            AppUser user = _userManager.GetUserAsync(User).Result;

            if (ModelState.IsValid)
            {
                ATask atask = new ATask
                {
                    Title = model.Title,
                    Description = model.Description,
                    AssignmentId = AssignmentId,
                    Assignment = await _assignmentService.GetAssignmentById(AssignmentId),
                    AppUser = _userManager.GetUserAsync(User).Result,
                    AppUserId = user.Id,
                    ATaskStatus = model.ATaskStatus,         
                    WrittenBy = user.UserName,
                    CreateTime = DateTime.Now,
                };

                await _taskService.NewATask(atask);
                return RedirectToAction("CreateAssignmentTask", new { AssignmentId });
            }
            return View(model);
        }


        //[HttpGet]
        //public async Task<IActionResult> DeleteTask(Guid teamid, string id)
        //{
        //    AppUser appUser = await _userManager.FindByIdAsync(id);
        //    Team team = await _teamService.GetTeamById(teamid);
        //    await _teamService.RemoveTeamUser(teamid, team, id, appUser);
        //    return RedirectToAction("AddTeamMember", "Manager", new { @id = teamid });
        //}
    }
}
