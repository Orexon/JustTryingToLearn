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
    public class AssignmentService : IAssignmentService
    {
        private readonly Context _context;

        public AssignmentService(Context context)
        {
            _context = context;
        }
        //All Assignments
        public async Task<List<Assignment>> GetAssignments() //Async
        {
            return await _context.Assignments.Include(x=>x.Team).ThenInclude(x => x.Company).ToListAsync();
        }
        //All Assignments
        public List<Assignment> GetAssignmentList()  //Synchronous
        {
            return _context.Assignments.ToList();
        }
        //All user Assingments.
        //public async Task<List<Assignment>> GetUserAssignmentList(Guid id)  //Synchronous
        //{
        //    return await _context.Assignments.Where(x=>x.AppUserId == id).ToListAsync();
        //}
        ////All user Assingments in a specific team.
        //public async Task<List<Assignment>> GetUserTeamAssignmentList(Guid userId, Guid TeamId)  //Synchronous
        //{
        //    return await _context.Assignments.Include(x=>x.Team).Where(x => x.AppUserId == userId && x.TeamId == TeamId).ToListAsync();
        //}
        //Get all Assingments of a specific team.
        public async Task<List<Assignment>> GetTeamAssingments(Guid TeamId) //Async
        {
            return await _context.Assignments.Where(x => x.Team.TeamId == TeamId).ToListAsync();
        }
        //Single Assignment by Id
        public async Task<Assignment> GetAssignmentById(Guid id)
        {
            return await _context.Assignments.FirstOrDefaultAsync(m => m.AssignmentId == id);
        }
        //Single Assignment by Id Overloaded.
        public async Task<Assignment> GetAssignmentById(string id)
        {
            Guid guidid = Guid.Parse(id);
            return await _context.Assignments.FirstOrDefaultAsync(m => m.AssignmentId == guidid);
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
    }
}
