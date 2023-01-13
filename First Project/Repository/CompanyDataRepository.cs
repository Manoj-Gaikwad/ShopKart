using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Project.Data;
using First_Project.IRepository;
using Microsoft.EntityFrameworkCore;

namespace First_Project.Repository
{
    
    public class CompanyDataRepository:ICompanyDataRepository
    {
        private readonly DBConnection dBConnection;

       public CompanyDataRepository(DBConnection dBConnection)
        {
            this.dBConnection = dBConnection;
        }
     
        public async Task<List<CompanyData>> getAllCompanies()
        {
            return await dBConnection.company.ToListAsync();
        }
        public async Task<CompanyData>getCompanyById(int id)
        {
            return await dBConnection.company.SingleOrDefaultAsync(x=>x.Id==id);
        }
        public async Task<CompanyData> updateCompany(CompanyData companyData)
        {
            CompanyData company = await dBConnection.company.SingleOrDefaultAsync(x => x.Id == companyData.Id);

            if(company!=null)
            {
                company.CName = companyData.CName;
                company.BranchName = companyData.BranchName;
                company.Address = companyData.BranchName;
                company.City = companyData.City;
            };
             await dBConnection.SaveChangesAsync();
            return company;
        }
        public async Task<CompanyData>addCompany(CompanyData companyData)
        {
            CompanyData company = new CompanyData()
            {
                Id = companyData.Id,
                CName = companyData.CName,
                BranchName = companyData.BranchName,
                Address = companyData.Address,
                City = companyData.City

            };
            await dBConnection.AddAsync(company);
            await dBConnection.SaveChangesAsync();

            return company;
        }

        public async Task<CompanyData>deletCompany(int id)
        {
            CompanyData company = await dBConnection.company.SingleOrDefaultAsync(x => x.Id == id);

            if (company != null)
            {
                dBConnection.Remove(company);
                //dBConnection.SaveChangesAsync();
               
            }
            return company;
        }
        

    }

    


}
