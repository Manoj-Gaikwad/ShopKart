using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Project.Data;
using First_Project.IRepository;

namespace First_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDetailsController : ControllerBase
    {
        private readonly ICompanyDataRepository iCompanyDataRepository;
       public CompanyDetailsController(ICompanyDataRepository iCompanyDataRepository)
        {
            this.iCompanyDataRepository = iCompanyDataRepository;
        }
      

        [HttpGet("getAllCompanies")]

        public async Task<List<CompanyData>>getAllCompanies()
        {
            return await iCompanyDataRepository.getAllCompanies();
        }
        [HttpGet("getCompanyById")]
        public async Task<CompanyData>getCompanyById(int id)
        {
            return await iCompanyDataRepository.getCompanyById(id);
        }


        [HttpPost("addCompanyDetails")]

        public async Task<CompanyData> addCompanyData(CompanyData companyData)
        {
            return await iCompanyDataRepository.addCompany(companyData);
        }
        [HttpPost("updateCompanyById")]
        public async Task<CompanyData> updateCompany(CompanyData companyData)
        {
            return await iCompanyDataRepository.updateCompany(companyData);
        }
        [HttpDelete("deletCompany")]
        public async Task<CompanyData>deletCompany(int id)
        {
            return await iCompanyDataRepository.deletCompany(id);
        }
        
    }
}
