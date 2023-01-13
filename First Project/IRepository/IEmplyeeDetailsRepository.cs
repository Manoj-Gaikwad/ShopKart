using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.IRepository
{
   public interface IEmplyeeDetailsRepository
    {
        Task<Boolean> AddEmployeeDetails(EmployeeDetails employeeDetails);
        Task<List<EmployeeDetails>> GetEmployeeDetails();
        Task<EmployeeDetails> GetEmployeeDetailsById(int id);
        Task<Boolean> UpdateEmployeeDetails(EmployeeDetails employeeDetails);
        Task<object> DeletEmployeeDetails(int id);
        Task<AllData> getAllDataWithEmpId(int id);
        Task<DepartmentData> get(int id);
        Task<List<Gender>> GetGender();
        Task<EmployeeDetails> getDataFromMobileNo(string contactno);
        //Task<AllData> Test(int id);
         
        }
}
