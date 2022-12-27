using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.IRepository
{
    public interface ICompanyDataRepository
    {
        Task<List<CompanyData>> getAllCompanies();
        Task<CompanyData> getCompanyById(int id);
        Task<CompanyData> addCompany(CompanyData companyData);
        Task<CompanyData> updateCompany(CompanyData companyData);
        Task<CompanyData> deletCompany(int id);
    }
}
