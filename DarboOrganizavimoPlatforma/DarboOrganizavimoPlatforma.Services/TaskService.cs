using DarboOrganizavimoPlatforma.Data;
using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Services
{
    public class TaskService : ITaskService
    {
        private readonly Context _context;

        public TaskService(Context context)
        {
            _context = context;
        }
        //All Tasks -  for admin.
        public async Task<List<ATask>> GetTasks() //Async
        {
            return await _context.ATasks.Include(x => x.Assignment).ThenInclude(x => x.Team).Include(x => x.AppUser).ThenInclude(x => x.Company).ToListAsync();
        }
        //All Assignment Tasks.
        public async Task<List<ATask>> GetAssignmentTasks(Guid assignmentId)
        {
            return await _context.ATasks.Include(x => x.Assignment).Include(x => x.AppUser).Where(x => x.AssignmentId == assignmentId).ToListAsync();
        }
        // New Assignment Task.
        public async Task NewATask(ATask aTask)
        {
            _context.ATasks.Add(aTask);
            await _context.SaveChangesAsync();
        }
        //Single Task by Id
        public async Task<ATask> GetTaskById(Guid taskId)
        {
            return await _context.ATasks.Include(x => x.AppUser).Include(x => x.Assignment).FirstOrDefaultAsync(m => m.ATaskId == taskId);
        }
        public async Task<ATask> GetTaskById(string taskId)
        {
            Guid guidTaskId = Guid.Parse(taskId);
            return await _context.ATasks.Include(x => x.AppUser).Include(x => x.Assignment).FirstOrDefaultAsync(m => m.ATaskId == guidTaskId);
        }

        public async Task<int> EditTask(ATask task)
        {
            _context.ATasks.Update(task);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteTask(ATask task)
        {
            _context.ATasks.Remove(task);
            return await _context.SaveChangesAsync();
        }

        //Gets ALL Tasks of User.
        public async Task<List<ATask>> GetUserAssignmentTaskList(Guid UserId)
        {
            List<ATask> userTasks = await _context.UserAssignments.Include(x => x.AppUser).Where(e => e.AppUser.Id == UserId).SelectMany(e => e.Assignment.AssignmentTasks).ToListAsync();
            return userTasks;
        }

        public async Task<List<ATask>> GetUseWrittenTaskList(Guid UserId)
        {
            List<ATask> userTasks = await _context.UserAssignments.Include(x => x.AppUser).Where(e => e.AppUser.Id == UserId).SelectMany(e => e.Assignment.AssignmentTasks.Where(x=>x.AppUserId == UserId)).ToListAsync();
            return userTasks;
        }

        //Gets All Company Tasks
        public async Task<List<ATask>> GetCompanyTasks(Guid companyId)
        {
            List<ATask> companyTasks = await _context.ATasks.Where(x => x.Company.CompanyId == companyId).Include(x=>x.Assignment).ToListAsync();
            return companyTasks;
        }

        //Gets All Company Tasks with status ToDo
        public async Task<List<ATask>> GetCompanyToDoTasks(Guid companyId)
        {
            List<ATask> companyTodoTasks = await _context.ATasks.Where(x => x.Company.CompanyId == companyId && x.ATaskStatus == CompletionStatus.ToDo).Include(x => x.Assignment).ToListAsync();
            return companyTodoTasks;
        }

        //Gets All Company Tasks with status InProgress
        public async Task<List<ATask>> GetCompanyInProgressTasks(Guid companyId)
        {
            List<ATask> CompanyInProgressTasks = await _context.ATasks.Where(x => x.Company.CompanyId == companyId && x.ATaskStatus == CompletionStatus.InProgress).Include(x => x.Assignment).ToListAsync();
            return CompanyInProgressTasks;
        }

        //Gets All Company Tasks with status Completed
        public async Task<List<ATask>> GetCompanyCompletedTasks(Guid companyId)
        {
            List<ATask> compnayCompletedTasks = await _context.ATasks.Where(x => x.Company.CompanyId == companyId && x.ATaskStatus == CompletionStatus.Done).Include(x => x.Assignment).ToListAsync();
            return compnayCompletedTasks;
        }
    }
}
