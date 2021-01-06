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

    }
}
