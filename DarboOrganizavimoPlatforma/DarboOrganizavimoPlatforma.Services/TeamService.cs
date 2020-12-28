using DarboOrganizavimoPlatforma.Data;
using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Services
{
    public class TeamService : ITeamService
    {
        private readonly Context _context;

        public TeamService(Context context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetTeams() //Async
        {
            return await _context.Teams.Include(x => x.Company).ToListAsync();
        }
        public async Task<List<Team>> GetCompanyTeams(Guid id) //Async
        {
            return await _context.Teams.Where(x => x.Company.CompanyId == id).ToListAsync();
        }

        public List<Team> GetTeamsList()  //Synchronous
        {
            return _context.Teams.ToList();
        }

        public async Task<Team> GetTeamById(Guid id)
        {
            return await _context.Teams.FirstOrDefaultAsync(m => m.TeamId == id);
        }

        public async Task NewTeam(Company company, Team newTeam)
        {
            company.Teams.Add(newTeam);
            _context.Teams.Add(newTeam);
            await _context.SaveChangesAsync();
        }

        public async Task<int> EditTeam(Team team)
        {
            _context.Teams.Update(team);
            return await _context.SaveChangesAsync();
        }

        //Admin Team Delete. 
        public async Task<int> DeleteTeam(Team team)
        {
            _context.Teams.Remove(team);
            return await _context.SaveChangesAsync();
        }
    }
}
