using First_Project.Data;
using First_Project.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace First_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        public readonly IEmplyeeDetailsRepository emplyeeDetailsRepository;
        private readonly IConfiguration configuration;

        public EmployeeDetailsController(IEmplyeeDetailsRepository emplyeeDetailsRepository, IConfiguration configuration)
        {
            this.emplyeeDetailsRepository = emplyeeDetailsRepository;
            this.configuration = configuration;
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

        public async Task<EmployeeDetails> GetEmployeeDetails(int id)
        {
            return await emplyeeDetailsRepository.GetEmployeeDetailsById(id);
        }

        [HttpPost("updateEmployeeDetails")]

        public async Task<Boolean> updateEmployeeDetails(EmployeeDetails employeeDetails)
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
       // [Authorize]
        public async Task<List<Gender>> GetGender()
        {
            return await emplyeeDetailsRepository.GetGender();
        }

        [HttpGet("getDataFromMobileNo/{contactno}")]
        public async Task<EmployeeDetails> getDataFromMobileNo(string contactno)
        {
            return await emplyeeDetailsRepository.getDataFromMobileNo(contactno);
        }
        //[HttpGet("GetAllDataOfEmployee/{id}")]

        //public async Task<AllData> GetAllDataOfEmployee(int id)
        //{
        //    return await emplyeeDetailsRepository.Test(id);
        //}

        [HttpPost("sendMail")]

        public async Task<Boolean> SendMail(MailData mailData)
        {
            
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(mailData.From));
            email.To.Add(MailboxAddress.Parse(mailData.To));
            email.Body = new TextPart(TextFormat.Html) { Text = mailData.Body };
            email.Subject = mailData.Subject;

            var smtp = new SmtpClient();
            smtp.Connect(configuration.GetValue<string>("SMTP:Host"), configuration.GetValue<int>("SMTP:Port"), MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(configuration.GetValue<string>("SMTP:UserName"), configuration.GetValue<string>("SMTP:Password"));
            smtp.Send(email);
            smtp.Disconnect(true);
            return true;
        }
    } 
    
}
