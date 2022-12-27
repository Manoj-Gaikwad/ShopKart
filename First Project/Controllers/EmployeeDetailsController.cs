using First_Project.Data;
using First_Project.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        public readonly IEmplyeeDetailsRepository emplyeeDetailsRepository;

        public EmployeeDetailsController(IEmplyeeDetailsRepository emplyeeDetailsRepository)
        {
            this.emplyeeDetailsRepository = emplyeeDetailsRepository;
        }

        [HttpPost("addEmployeeDetails")]
        public async Task<Boolean> AddEmployeeDetailsp(EmployeeDetails employeeDetails)
        {
            return await emplyeeDetailsRepository.AddEmployeeDetails(employeeDetails);
        }


        [HttpGet("getAllEmployeeDetails")]

        public async Task<List<EmployeeDetails>> GetEmployeeDetails()
        {
            return await emplyeeDetailsRepository.GetEmployeeDetails();
        }

        [HttpGet("getEmployeeDetailsById/{id}")]
        
           public async Task<EmployeeDetails>GetEmployeeDetails(int id)
        {
            return await emplyeeDetailsRepository.GetEmployeeDetailsById(id);
        }

        [HttpPost("updateEmployeeDetails")]

        public async Task<Boolean>updateEmployeeDetails(EmployeeDetails employeeDetails)
        {
            return await emplyeeDetailsRepository.UpdateEmployeeDetails(employeeDetails);
        }
        [HttpGet("deletEmployeeDetails/{id}")]
        public async Task<object> deletEmployeeDetails(int id)
        {
            return await emplyeeDetailsRepository.DeletEmployeeDetails(id);
        }
        [HttpGet("getAllWithId")]

        public async Task<AllData> getAllDataWithEmpId(int id)
        {
            return await emplyeeDetailsRepository.getAllDataWithEmpId(id);
        }
        [HttpGet("getDepartment")]
        public async Task<DepartmentData> get(int id)
        {
            return await emplyeeDetailsRepository.get(id);
        }
        [HttpGet("getAllGender")]
        public async Task<List<Gender>> GetGender()
        {
            return await emplyeeDetailsRepository.GetGender();
        }

        [HttpGet("getDataFromMobileNo/{contactno}")]
        public async Task<EmployeeDetails> getDataFromMobileNo(string contactno)
        {
            return await emplyeeDetailsRepository.getDataFromMobileNo(contactno);
        }
    }
    
}
