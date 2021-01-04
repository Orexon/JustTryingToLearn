using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Services.Interfaces
{
    public interface IAssignmentService
    {
        Task<List<Assignment>> GetAssignments();
        List<Assignment> GetAssignmentList();
        //Task<List<Assignment>> GetUserAssignmentList(Guid id);
        //Task<List<Assignment>> GetUserTeamAssignmentList(Guid id, Guid TeamId);
        Task<List<Assignment>> GetTeamAssingments(Guid TeamId);
        Task<Assignment> GetAssignmentById(Guid id);
        Task<Assignment> GetAssignmentById(string id);
        Task NewAssignment(Assignment newAssignment);
        Task<int> EditAssignment(Assignment assignment);
        Task<int> DeleteAssignment(Assignment assignment);
    }
}
