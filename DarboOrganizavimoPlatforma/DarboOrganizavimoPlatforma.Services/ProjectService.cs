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

        public ProjectService(Context context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetProjects() //Async
        {
            return await _context.Projects.Include(x => x.ProjectTeams).ToListAsync();
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
        public async Task NewProject(Company company, Project newProject)
        {
            company.CompanyProjects.Add(newProject);
            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();
        }
    }
}
