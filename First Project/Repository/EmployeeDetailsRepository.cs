using First_Project.Data;
using First_Project.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Repository
{
    public class EmployeeDetailsRepository : IEmplyeeDetailsRepository
    {
        private readonly DBConnection dBConnection;
        public EmployeeDetailsRepository(DBConnection dBConnection)
        {
            this.dBConnection = dBConnection;

        }

        public async Task<Boolean> AddEmployeeDetails(EmployeeDetails employeeDetails)
        {
            if (employeeDetails != null)
            {
                EmployeeDetails details = new EmployeeDetails()
                {

                    FirstName = employeeDetails.FirstName,
                    LastName = employeeDetails.LastName,
                    DOB = employeeDetails.DOB,
                    Email = employeeDetails.Email,
                    Gender = employeeDetails.Gender,
                    Address = employeeDetails.Address,
                    Pincode = employeeDetails.Pincode,
                    ContactNo = employeeDetails.ContactNo,
                    Password = employeeDetails.Password,
                    CPassword = employeeDetails.CPassword,

                };
                await dBConnection.AddAsync(details);
                await dBConnection.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<EmployeeDetails>> GetEmployeeDetails()
        {
            return await dBConnection.employeeDetails.ToListAsync();
        }

        public async Task<EmployeeDetails> GetEmployeeDetailsById(int id)
        {
            return await dBConnection.employeeDetails.SingleOrDefaultAsync(x => x.EmpId == id);
        }

        public async Task<Boolean> UpdateEmployeeDetails(EmployeeDetails employeeDetails)
        {
            EmployeeDetails detils = new EmployeeDetails();

            {
                EmployeeDetails employee = await dBConnection.employeeDetails.SingleOrDefaultAsync(x => x.EmpId == employeeDetails.EmpId);

                if (employee != null)
                {
                    employee.EmpId = employeeDetails.EmpId;
                    employee.FirstName = employeeDetails.FirstName;
                    employee.LastName = employeeDetails.LastName;
                    employee.DOB = employeeDetails.DOB;
                    employee.Email = employeeDetails.Email;
                    employee.Gender = employeeDetails.Gender;
                    employee.Address = employeeDetails.Address;
                    employee.Pincode = employeeDetails.Pincode;
                    employee.ContactNo = employeeDetails.ContactNo;
                    await dBConnection.SaveChangesAsync();
                    return true;
                }
                else
                {

                    return false;
                }
            }
        }

        public async Task<object> DeletEmployeeDetails(int id)
        {
            EmployeeDetails employee = await dBConnection.employeeDetails.SingleOrDefaultAsync(x => x.EmpId == id);
            if (employee != null)
            {
                dBConnection.Remove(employee);
                await dBConnection.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<AllData> getAllDataWithEmpId(int id)
        {
            var Data = await (from EmployeeDetails in dBConnection.employeeDetails
                              join DepartmentData in dBConnection.department
                              on EmployeeDetails.EmpId equals DepartmentData.EmpId
                              where EmployeeDetails.EmpId == id & DepartmentData.EmpId == EmployeeDetails.EmpId
                              select new AllData()
                              {
                                  EmpId = EmployeeDetails.EmpId,
                                  FirstName = EmployeeDetails.FirstName,
                                  LastName = EmployeeDetails.LastName,
                                  DOB = EmployeeDetails.DOB,
                                  Email = EmployeeDetails.Email,
                                  Gender = EmployeeDetails.Gender,
                                  Address = EmployeeDetails.Address,
                                  Pincode = EmployeeDetails.Pincode,
                                  ContactNo=EmployeeDetails.ContactNo,
                                  DName = DepartmentData.DName
                              }).FirstOrDefaultAsync();
            return Data;

        }

        public async Task<DepartmentData> get(int id)
        {
            return await dBConnection.department.SingleOrDefaultAsync(x => x.EmpId == id);

        }

        public async Task<List<Gender>> GetGender()
        {
            return await dBConnection.gender.ToListAsync();
        }

        public async Task<EmployeeDetails> getDataFromMobileNo(string contactno)
        {
            return await dBConnection.employeeDetails.SingleOrDefaultAsync(x => x.ContactNo == contactno);
        }

        public async Task<EmployeeDetails> Testing(string contactno)
        {
            return await dBConnection.employeeDetails.SingleOrDefaultAsync(x => x.ContactNo == contactno);
        }


    }
}

