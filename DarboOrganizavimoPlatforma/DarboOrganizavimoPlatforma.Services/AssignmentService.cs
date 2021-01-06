﻿using DarboOrganizavimoPlatforma.Data;
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
    public class AssignmentService : IAssignmentService
    {
        private readonly Context _context;
        private readonly ITeamService _teamService;

        public AssignmentService(Context context, ITeamService teamService)
        {
            _context = context;
            _teamService = teamService;
        }
        //All Assignments for admin.
        public async Task<List<Assignment>> GetAssignments() //Async
        {
            return await _context.Assignments.Include(x=>x.Team).ThenInclude(x => x.Company.CompanyName).Include(x => x.UsersAssigned).ToListAsync();
        }
        //All Assignments for admin.
        public List<Assignment> GetAssignmentList()  //Synchronous
        {
            return _context.Assignments.Include(x => x.UsersAssigned).Include(x=>x.Team).ToList();
        }

        //Gets ALL assignments of User.
        public async Task<List<Assignment>> GetUserAssignmentList(Guid UserId) 
        {
            List<Assignment> userAssingments = await _context.UserAssingments.Include(x => x.AppUser).Where(e => e.AppUser.Id == UserId).Select(e => e.Assignment).ToListAsync();
            return userAssingments;
        }
        //Gets ALL assignments of User in a specific Team. 
        public async Task<List<Assignment>> GetUserTeamAssignmentList(Guid UserId, Guid TeamId) 
        {
            List<Assignment> userTeamAssignments = await _context.UserAssingments.Include(x => x.Assignment).Where(x => x.Assignment.TeamId == TeamId && x.AppUserId == UserId).Select(e => e.Assignment).ToListAsync();
            return userTeamAssignments;
        }
        //Gets ALL Users assigned to a specific Assingment. 
        public async Task<List<AppUser>> GetAssignmentUserList(Guid AssignmentId) 
        {
            List<AppUser> AssignmentUsers = await _context.UserAssingments.Include(x => x.Assignment).Where(x => x.AssingmentId == AssignmentId).Include(x=>x.AppUser).Select(e => e.AppUser).ToListAsync();
            return AssignmentUsers;
        }
        //Gets all Users assigned to a specific Team but not assigned to a specific Assingment. 
        public async Task<List<AppUser>> GetListOfAvailableAssignmentUsers(Guid TeamId, Guid AssignmentId)
        {
            List<AppUser> teamMemberList = await _teamService.GetTeamsMemberList(TeamId);
            List<AppUser> AssignmentUserList = await GetAssignmentUserList(AssignmentId);
            List<AppUser> availableAssignmentUsers = teamMemberList.Except(AssignmentUserList).ToList();

            return availableAssignmentUsers;
        }

        //Get all Assingments of a specific team.
        public async Task<List<Assignment>> GetTeamAssingments(Guid TeamId) 
        {
            return await _context.Assignments.Include(x=>x.Team).Where(x => x.Team.TeamId == TeamId).ToListAsync();
        }

        //Single Assignment by Id
        public async Task<Assignment> GetAssignmentById(Guid id)
        {
            return await _context.Assignments.FirstOrDefaultAsync(m => m.AssignmentId == id);
        }

        //Single Assignment by Id Overloaded.
        public async Task<Assignment> GetAssignmentById(string id)
        {
            Guid assignmentId = Guid.Parse(id);
            return await _context.Assignments.FirstOrDefaultAsync(m => m.AssignmentId == assignmentId);
        }
        //New Assignment
        public async Task NewAssignment(Assignment newAssignment)
        {
            _context.Assignments.Add(newAssignment);
            await _context.SaveChangesAsync();
        }
        //Edit Assignment
        public async Task<int> EditAssignment(Assignment assignment)
        {
            _context.Assignments.Update(assignment);
            return await _context.SaveChangesAsync();
        }
        //Delete Assignment
        public async Task<int> DeleteAssignment(Assignment assignment)
        {
            _context.Assignments.Remove(assignment);
            return await _context.SaveChangesAsync();
        }

        //Add new UserAssignment. InOtherWords Assign User to an Assigment.
        public async Task AddUserAssignment(UserAssingment userAssingment)
        {
            _context.UserAssingments.Add(userAssingment);
            await _context.SaveChangesAsync();
        }
        //Remove UserAssignment. InOtherWords Remove User from an Assigment.
        public async Task<int> RemoveUserAssignment(Guid AssignmentId, Assignment assignment, string id, AppUser appUser)
        {
            Guid userIdGuid = Guid.Parse(id);
            UserAssingment userAssingment = _context.UserAssingments.Where(x => x.AssingmentId == AssignmentId && x.Assignment == assignment && x.AppUserId == userIdGuid && x.AppUser == appUser).FirstOrDefault();
            _context.UserAssingments.Remove(userAssingment);
            return await _context.SaveChangesAsync();
        }
        //Change status to In Progress.
        public async Task<int> ChangeStatusToInProgress(Guid AssignmentId) //
        {
            Assignment assignment = await GetAssignmentById(AssignmentId);
            assignment.AssingmentStatus = CompletionStatus.InProgress;
            return await _context.SaveChangesAsync();
        }

        //Get TeamID if only have assignment id. 
        public async Task<Guid> GetTeamByAssingmentId(Guid AssignmentId)
        {
            Assignment assignment = await GetAssignmentById(AssignmentId);
            Guid TeamId = await _context.Teams.Include(x => x.TeamAssignments).Where(x => x.TeamAssignments.Contains(assignment)).Select(e => e.TeamId).FirstOrDefaultAsync();
            return TeamId;
        }
    }
}
