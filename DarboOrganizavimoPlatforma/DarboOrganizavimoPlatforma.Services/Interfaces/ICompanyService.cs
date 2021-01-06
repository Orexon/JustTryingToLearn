using DarboOrganizavimoPlatforma.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetCompanies();
        List<Company> GetCompaniesList();
        Task<List<AppUser>> GetCompanyMembersList(Guid companyId);
        Task<Company> GetCompanyById(Guid id);
        Task<Company> GetCompanyById(string id);
        Task<Company> FindCompanyById(Guid id);
        Task NewCompany(Company newCompany);
        Task AddUserToCompany(Company company);
        Task<int> EditCompany(Company company);
        Task<int> DeleteCompany(Company company);
    }
}
