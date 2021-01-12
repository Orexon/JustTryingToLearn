using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{
    [Authorize(Roles = "Admin,Manager,Member")]
    public class ATaskController : Controller
    {
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

        //Gets all company Tasks - for manager.
        public async Task<IActionResult> GetCompanyTasks()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid companyId = user.CompanyId;

            CompanyTasksViewModel model = new CompanyTasksViewModel()
            {
                AllCompanyTasks = await _taskService.GetCompanyTasks(companyId)
            };
            return View(model);
        }

        //Create Task When Choosing Assignment.
        [HttpGet]
        public async Task<IActionResult> CreateTask()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid companyId = user.CompanyId;
            ViewBag.companyAssignments = new SelectList(await _assignmentService.GetCompanyAssignments(companyId), "AssignmentId", "AssignmentName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskViewModel model)
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid companyId = user.CompanyId;
            ViewBag.companyAssignments = new SelectList(await _assignmentService.GetCompanyAssignments(companyId), "AssignmentId", "AssignmentName");

            if (ModelState.IsValid)
            {
                Guid guidAssignmentId = Guid.Parse(model.AssignmentId);

                ATask atask = new ATask
                {
                    Company = await _companyService.GetCompanyById(companyId),
                    Title = model.Title,
                    Description = model.Description,
                    AssignmentId = guidAssignmentId,
                    Assignment = await _assignmentService.GetAssignmentById(guidAssignmentId),
                    AppUser = _userManager.GetUserAsync(User).Result,
                    AppUserId = user.Id,
                    ATaskStatus = model.ATaskStatus,
                    WrittenBy = user.UserName,
                    CreateTime = DateTime.Now,
                };

                await _taskService.NewATask(atask);
                return RedirectToAction("CreateAssignmentTask", new { guidAssignmentId });
            }
            return View(model);
        }


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
        public async Task<IActionResult> EditTask(Guid id, Guid? assignmentId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ATask task = await _taskService.GetTaskById(id);

            EditTaskViewModel model = new EditTaskViewModel()
            {
                AssignmentId = assignmentId,
                Title = task.Title,
                Description = task.Description,
                ATaskStatus = task.ATaskStatus
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTask(Guid id, Guid assignmentId, EditTaskViewModel model)
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
                    if (assignmentId != null && assignmentId != Guid.Empty)
                    {
                        return RedirectToAction("CreateAssignmentTask", "ATask", new { assignmentId });
                    }
                    return RedirectToAction("GetCompanyTasks", "ATask");
                }
                else if (await _userManager.IsInRoleAsync(currentUser, "Member")) 
                {
                    return RedirectToAction("GetMemberAssignmentsTasks", "Member");
                }
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

        [HttpGet]
        public async Task<IActionResult> DeleteTask(Guid id, Guid? assignmentId)
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            ATask aTask = await _taskService.GetTaskById(id);
            await _taskService.DeleteTask(aTask);

            if (await _userManager.IsInRoleAsync(currentUser, "Manager"))
            {
                if (assignmentId != null)
                {
                    return RedirectToAction("CreateAssignmentTask", "ATask", new { assignmentId });
                }
                return RedirectToAction("GetCompanyTasks", "ATask");
            }
            return RedirectToAction("GetAllTasks", "ATask");
        }
    }
}
