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
        private readonly ICompanyService _companyService;

        public ATaskController(UserManager<AppUser> userManager, IAssignmentService assignmentService, ITaskService taskService, ICompanyService companyService)
        {
            _userManager = userManager;
            _assignmentService = assignmentService;
            _taskService = taskService;
            _companyService = companyService;
        }

        //Get All Tasks for Admin
        public async Task<IActionResult> GetAllTasks()
        {
            return View(await _taskService.GetTasks());
        }

        //public async Task<IActionResult> GetCompanyTasks()
        //{
        //    AppUser user = _userManager.GetUserAsync(User).Result;
        //    Guid companyId = user.CompanyId;
        //    // Get Company Tasks List. 
        //    // Get completed 
        //    // In Progress
        //    // To do

        //    CompanyTasksViewModel model = new CompanyTasksViewModel()
        //    {

        //    };
        //    return View(model);


        //    return View();
        //}

        //Create Task For Manager/User when viewing from assigment.
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
                AssignmentTasks = await _taskService.GetAssignmentTasks(assignmentId)
            };
            return View(newviewmodel);
        }     

        [HttpPost]
        public async Task<IActionResult> CreateAssignmentTask(NewAssignmentTaskViewModel model, Guid AssignmentId)
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid companyId = user.CompanyId;

            if (ModelState.IsValid)
            {
                ATask atask = new ATask
                {
                    Company = await _companyService.GetCompanyById(companyId),
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


        [HttpGet]
        public async Task<IActionResult> EditTask(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ATask task = await _taskService.GetTaskById(id);

            EditTaskViewModel model = new EditTaskViewModel()
            {
                Title = task.Title,
                Description = task.Description,
                ATaskStatus = task.ATaskStatus
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTask(Guid id, EditTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                ATask task = await _taskService.GetTaskById(id);
                AppUser currentUser = _userManager.GetUserAsync(User).Result;

                task.Title = model.Title;
                task.Description = model.Description;
                task.ATaskStatus = model.ATaskStatus;
                if (model.ATaskStatus == CompletionStatus.Done)
                {
                    task.CompleteTime = DateTime.Now;
                }
                await _taskService.EditTask(task);

                if (await _userManager.IsInRoleAsync(currentUser, "Manager"))
                {
                    //IF MANAGER RETURN WHERE?
                    return RedirectToAction("", "Manager");
                }
                //ELSE IF MEMBER/TEAM LEADER, return where.
                return RedirectToAction("GetAllTasks", "ATask");
            }
            return View(model);
        }

        public async Task<IActionResult> TaskDetails(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ATask aTask = await _taskService.GetTaskById(id);

            if (aTask == null)
            {
                return NotFound();
            }
            return View(aTask);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            ATask aTask = await _taskService.GetTaskById(id);
            await _taskService.DeleteTask(aTask);

            if (await _userManager.IsInRoleAsync(currentUser, "Manager"))
            {
                //IF MANAGER RETURN WHERE?
                return RedirectToAction("", "Manager");
            }
            return RedirectToAction("GetAllTasks", "ATask");
        }
    }
}
