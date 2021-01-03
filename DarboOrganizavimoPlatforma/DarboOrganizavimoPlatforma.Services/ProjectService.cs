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
    public class ProjectService : IProjectService
    {
        private readonly Context _context;
        private readonly ITeamService _teamService;

        public ProjectService(Context context, ITeamService teamService)
        {
            _context = context;
            _teamService = teamService;
        }
        public async Task<List<Project>> GetProjects() //Async
        {
            return await _context.Projects.Include(x => x.ProjectTeams).Include(x=>x.Company).ToListAsync();
        }

        public List<Project> GetProjectList()  //Synchronous
        {
            return _context.Projects.ToList();
        }

        public async Task<Project> GetProjectById(Guid id)
        {
            return await _context.Projects.FirstOrDefaultAsync(m => m.ProjectId == id);
        }

        public async Task<Project> GetProjectById(string id)
        {
            Guid guidid = Guid.Parse(id);
            return await _context.Projects.FirstOrDefaultAsync(m => m.ProjectId == guidid);
        }

        public async Task NewProject(Project newProject)
        {
            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();
        }

        public async Task<int> EditProject(Project project)
        {
            _context.Projects.Update(project);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Project>> GetCompanyProjects(Guid id) //Async
        {
            return await _context.Projects.Where(x => x.Company.CompanyId == id).ToListAsync();
        }
        
        public async Task<List<Team>> GetProjectTeamList(Guid projectId)
        {
            List<Team> projectTeams = await _context.ProjectTeams.Include(x=>x.Team).Where(e => e.Project.ProjectId == projectId).Select(e => e.Team).ToListAsync();
            return projectTeams;
        }

        public async Task<List<Team>> GetListOfAvailableProjectTeams(Guid projectId, Guid companyId)
        {
            List<Team> companyTeamList = await _teamService.GetCompanyTeams(companyId);
            List<Team> projectTeamList = await GetProjectTeamList(projectId);
            List<Team> availableProjectTeams = companyTeamList.Except(projectTeamList).ToList();
            return availableProjectTeams;
        }

        public async Task AddProjectTeam(ProjectTeam projectTeam)
        {
            _context.ProjectTeams.Add(projectTeam);
            await _context.SaveChangesAsync();
        }

        //Remove Project Team from Project (deletes Team data in ProjectTeam table)
        public async Task<int> RemoveProjectTeam(string TeamId, Guid projectId)
        {
            Guid guidid = Guid.Parse(TeamId);
            ProjectTeam projectTeam = await _context.ProjectTeams.FindAsync(guidid, projectId);
            _context.ProjectTeams.Remove(projectTeam);
            return await _context.SaveChangesAsync();
        }

    }
}
