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
        public async Task<Team> GetTeamById(string id)
        {
            Guid guidid = Guid.Parse(id);
            return await _context.Teams.FirstOrDefaultAsync(m => m.TeamId == guidid);
        }
        public async Task<Team> GetTeamByUserId(string id)
        {
            Guid guidid = Guid.Parse(id);
            return await _context.Teams.FirstOrDefaultAsync(m => m.TeamId == guidid);
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

        public async Task NewTeam(Team newTeam)
        {
            _context.Teams.Add(newTeam);
            await _context.SaveChangesAsync();
        }

        public async Task AddTeamUser(TeamUser teamUser)
        {
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

        //Remove Team User from Team (deletes User data in TeamUser table)
        public async Task<int> RemoveTeamUser(Guid teamid,Team team, string id, AppUser appUser)
        {
            Guid guidid = Guid.Parse(id);
            TeamUser teamUser = _context.TeamUsers.Where(x => x.TeamId == teamid && x.AppUserId == guidid && x.AppUser == appUser && x.Team == team).FirstOrDefault();
            _context.TeamUsers.Remove(teamUser);
            return await _context.SaveChangesAsync();
        }
    }
}
