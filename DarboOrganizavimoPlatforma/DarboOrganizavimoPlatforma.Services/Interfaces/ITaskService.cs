using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<ATask>> GetTasks();
        Task<List<ATask>> GetAssignmentTasks(Guid assignmentId);
        Task NewATask(ATask aTask);
        Task<ATask> GetTaskById(Guid taskId);
        Task<ATask> GetTaskById(string taskId);
        Task<int> EditTask(ATask task);
        Task<int> DeleteTask(ATask task);
        Task<List<ATask>> GetCompanyTasks(Guid companyId);
        Task<List<ATask>> GetCompanyToDoTasks(Guid companyId);
        Task<List<ATask>> GetCompanyInProgressTasks(Guid companyId);
        Task<List<ATask>> GetCompanyCompletedTasks(Guid companyId);
        Task<List<ATask>> GetUserAssignmentTaskList(Guid UserId);
        Task<List<ATask>> GetUseWrittenTaskList(Guid UserId);
    }
}
