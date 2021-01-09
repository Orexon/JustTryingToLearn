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
            return await _context.ATasks.Include(x => x.Assignment).ThenInclude(x => x.Team).Include(x=>x.AppUser).ThenInclude(x => x.Company).ToListAsync();
        }
        //All Assignment Tasks.
        public async Task<List<ATask>> GetAssignmentTasks(Guid assignmentId)
        {
            return await _context.ATasks.Include(x => x.Assignment).Include(x=>x.AppUser).Where(x => x.AssignmentId == assignmentId).ToListAsync();
        }
        // New Assignment Task.
        public async Task NewATask(ATask aTask)
        {
            _context.ATasks.Add(aTask);
            await _context.SaveChangesAsync();
        }



        ////Gets ALL assignments of User.
        //public async Task<List<Assignment>> GetUserAssignmentList(Guid UserId)
        //{
        //    List<Assignment> userAssignments = await _context.UserAssignments.Include(x => x.AppUser).Where(e => e.AppUser.Id == UserId).Select(e => e.Assignment).ToListAsync();
        //    return userAssignments;
        //}
        ////Gets ALL assignments of User in a specific Team. 
        //public async Task<List<Assignment>> GetUserTeamAssignmentList(Guid UserId, Guid TeamId)
        //{
        //    List<Assignment> userTeamAssignments = await _context.UserAssignments.Include(x => x.Assignment).Where(x => x.Assignment.TeamId == TeamId && x.AppUserId == UserId).Select(e => e.Assignment).ToListAsync();
        //    return userTeamAssignments;
        //}
        ////Gets ALL Users assigned to a specific Assignment. 
        //public async Task<List<AppUser>> GetAssignmentUserList(Guid AssignmentId)
        //{
        //    List<AppUser> AssignmentUsers = await _context.UserAssignments.Include(x => x.Assignment).Where(x => x.AssignmentId == AssignmentId).Include(x => x.AppUser).Select(e => e.AppUser).ToListAsync();
        //    return AssignmentUsers;
        //}
        ////Gets all Users assigned to a specific Team but not assigned to a specific Assignment. 
        //public async Task<List<AppUser>> GetListOfAvailableAssignmentUsers(Guid TeamId, Guid AssignmentId)
        //{
        //    List<AppUser> teamMemberList = await _teamService.GetTeamsMemberList(TeamId);
        //    List<AppUser> AssignmentUserList = await GetAssignmentUserList(AssignmentId);
        //    List<AppUser> availableAssignmentUsers = teamMemberList.Except(AssignmentUserList).ToList();

        //    return availableAssignmentUsers;
        //}

        ////Get all Assignments of a specific team.
        //public async Task<List<Assignment>> GetTeamAssignments(Guid TeamId)
        //{
        //    return await _context.Assignments.Include(x => x.Team).Include(x => x.UsersAssigned).Where(x => x.Team.TeamId == TeamId).ToListAsync();
        //}

        ////Single Assignment by Id
        //public async Task<Assignment> GetAssignmentById(Guid id)
        //{
        //    return await _context.Assignments.Include(x => x.Team).Include(x => x.UsersAssigned).FirstOrDefaultAsync(m => m.AssignmentId == id);
        //}

        ////Single Assignment by Id Overloaded.
        //public async Task<Assignment> GetAssignmentById(string id)
        //{
        //    Guid assignmentId = Guid.Parse(id);
        //    return await _context.Assignments.FirstOrDefaultAsync(m => m.AssignmentId == assignmentId);
        //}
        ////New Assignment
        //public async Task NewAssignment(Assignment newAssignment)
        //{
        //    _context.Assignments.Add(newAssignment);
        //    await _context.SaveChangesAsync();
        //}

    }
}
