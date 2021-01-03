using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjects();
        List<Project> GetProjectList();
        Task<Project> GetProjectById(Guid id);
        Task<Project> GetProjectById(string id);
    }
}
