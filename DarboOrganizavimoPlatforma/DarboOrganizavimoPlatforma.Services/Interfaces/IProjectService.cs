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
        Task<List<Project>> GetCompanyProjects(Guid id);
        Task<List<Team>> GetProjectTeamList(Guid projectId);
        Task<List<Team>> GetListOfAvailableProjectTeams(Guid projectId, Guid companyId);
        Task AddProjectTeam(ProjectTeam projectTeam);
        Task NewProject(Project newProject);
        Task<int> EditProject(Project project);
        Task<int> DeleteProject(Project project);
        Task<int> RemoveProjectTeam(string TeamId, Guid projectId);
    }
}
