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
        Task<List<Assignment>> GetUserAssignmentList(Guid UserId);
        Task<List<Assignment>> GetUserTeamAssignmentList(Guid UserId, Guid TeamId);
        Task<List<Assignment>> GetTeamAssignments(Guid TeamId);
        Task<List<AppUser>> GetAssignmentUserList(Guid AssignmentId);
        Task<List<AppUser>> GetListOfAvailableAssignmentUsers(Guid TeamId, Guid AssignmentId);
        Task<Assignment> GetAssignmentById(Guid id);
        Task<Assignment> GetAssignmentById(string id);
        Task NewAssignment(Assignment newAssignment);
        Task<int> EditAssignment(Assignment assignment);
        Task<int> DeleteAssignment(Assignment assignment);
        Task AddUserAssignment(UserAssignment userAssignment);
        Task<int> RemoveUserAssignment(Guid AssignmentId, Assignment assignment, string id, AppUser appUser);
        Task<int> ChangeStatusToInProgress(Guid AssignmentId);
        Task<Guid> GetTeamByAssignmentId(Guid AssignmentId);
        Task<List<ATask>> GetAssignmentTasks(Guid assignmentId);
        Task<List<Assignment>> GetCompanyAssignments(Guid companyId);
    }
}
