﻿using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Services.Interfaces
{
    public interface ITeamService
    {
        Task<List<Team>> GetTeams();
        List<Team> GetTeamsList();
        Task<Team> GetTeamById(Guid id);
        Task<Team> GetCompanyById(string id);
        Task<List<AppUser>> GetTeamsMemberList(Guid id);
        Task<List<AppUser>> GetListOfAvailableTeamUsers(Guid id, Guid companyId);
        Task<List<Team>> GetCompanyTeams(Guid id);
        Task NewTeam(Company company, Team newTeam);
        Task AddTeamUser(TeamUser teamUser);
        Task<int> EditTeam(Team team);
        Task<int> DeleteTeam(Team team);
    }
}
