﻿using DarboOrganizavimoPlatforma.Data;
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

        //public async Task<List<AppUser>> GetTeamsMemberList(Guid id)
        //{
        //    return await _context.TeamUsers.Where(e => e.Team.TeamId == id).Select(e => e.AppUser).ToListAsync();
        //    //await _context.TeamUsers.Include(x => x.AppUser).Where(x => x.TeamId == id).ToListAsync();   Works But From other side. 
        //}

        //public async Task<List<AppUser>> GetListOfAvailableTeamUsers(Guid teamId)
        //{
        //    Team team = await GetTeamById(teamId);
        //    Guid companyId = team.CompanyId;
        //    List<AppUser> companyMemberList = await _companyService.GetCompanyMembersList(companyId);
        //    //List<AppUser> teamMembersList = await GetTeamsMemberList(teamId);

        //    //List<AppUser> availableTeamUsers = companyMemberList.Except(teamMembersList);
        //    //Workaourd to comparing complex lists. 
        //    //List<Guid> comparableIds = (List<Guid>)companyMemberList.Select(c => c.Id).Except(teamMembersList.Select(c => c.Id));
        //   // List<AppUser> availableTeamUsers = (List<AppUser>)companyMemberList.Where(c => comparableIds.Contains(c.Id));

        //    //return availableTeamUsers;
        //}
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
