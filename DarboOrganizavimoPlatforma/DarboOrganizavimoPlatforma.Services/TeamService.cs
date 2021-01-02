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
        private readonly ICompanyService _companyService;

        public TeamService(Context context, ICompanyService companyService)
        {
            _context = context;
            _companyService = companyService;
        }

        public async Task<List<Team>> GetTeams() //Async
        {
            return await _context.Teams.Include(x => x.Company).ToListAsync();
        }
        public List<Team> GetTeamsList()  //Synchronous
        {
            return _context.Teams.ToList();
        }

        public async Task<Team> GetTeamById(Guid id)
        {
            return await _context.Teams.FirstOrDefaultAsync(m => m.TeamId == id);
        }

        public async Task<List<TeamUser>> GetTeamsUsers()
        {
            return await _context.TeamUsers.ToListAsync();
        }
        // "Points" to a team and gives list of TeamMembers.
        public async Task<List<AppUser>> GetTeamsMemberList(Guid id)
        {

            List<AppUser> teamMembers = await _context.TeamUsers.Where(e => e.Team.TeamId == id).Select(e => e.AppUser).ToListAsync();
            return teamMembers;
            //await _context.TeamUsers.Include(x => x.AppUser).Where(x => x.TeamId == id).ToListAsync();   Works But From other side. ;
        }

        public async Task<List<AppUser>> GetListOfAvailableTeamUsers(Guid id, Guid companyId)
        {
            //Team team = await GetTeamById(id);
            //Guid companyId = team.Company.CompanyId; Neleidzia. Pasikartojantis error, Company null. 

            List<AppUser> companyMemberList = await _companyService.GetCompanyMembersList(companyId);
            List<AppUser> teamMembersList = await GetTeamsMemberList(id);

            List<AppUser> availableTeamUsers = companyMemberList.Except(teamMembersList).ToList();

            //Workaourd to comparing complex lists. 
            //List<Guid> comparableIds = companyMemberList.Select(c => c.Id).Except(teamMembersList.Select(c => c.Id));
            //List<AppUser> availableTeamUsers = companyMemberList.Where(c => comparableIds.Contains(c.Id));

            return availableTeamUsers;
        }
        public async Task<List<Team>> GetCompanyTeams(Guid id) //Async
        {
            return await _context.Teams.Where(x => x.Company.CompanyId == id).ToListAsync();
        }

        public async Task NewTeam(Company company, Team newTeam)
        {
            company.Teams.Add(newTeam);
            _context.Teams.Add(newTeam);
            await _context.SaveChangesAsync();
        }

        public async Task AddTeamUser(Guid teamId, TeamUser teamUser)
        {
            Team team = await GetTeamById(teamId);
            team.TeamUsers.Add(teamUser);
            _context.TeamUsers.Add(teamUser);
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
