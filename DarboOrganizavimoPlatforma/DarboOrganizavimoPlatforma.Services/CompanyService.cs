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
    public class CompanyService : ICompanyService
    {
        private readonly Context _context;

        public CompanyService(Context context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public List<Company> GetCompaniesList()
        {
            return _context.Companies.ToList();
        }

        public async Task<Company> GetCompanyById(Guid id)
        {  
            return  await _context.Companies.FirstOrDefaultAsync(m => m.CompanyId == id);             
        }

        public async Task<Company> GetCompanyById(string id)
        {
            Guid guidid = Guid.Parse(id);
            return await _context.Companies.FirstOrDefaultAsync(m => m.CompanyId == guidid);
        }

        public async Task<List<AppUser>> GetCompanyMembersList(Guid companyId)
        {
            Company company = await _context.Companies.Include(x=>x.AppUsers).FirstOrDefaultAsync(m => m.CompanyId == companyId);
            return company.AppUsers;
        }

        public async Task<Company> FindCompanyById(Guid id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task NewCompany(Company newCompany)
        {
            _context.Companies.Add(newCompany);
            await _context.SaveChangesAsync();
        }

        public async Task<int> EditCompany(Company company)
        {
            _context.Companies.Update(company);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCompany(Company company)
        {
            _context.Companies.Remove(company);
            return await _context.SaveChangesAsync();
        }
    }
}
