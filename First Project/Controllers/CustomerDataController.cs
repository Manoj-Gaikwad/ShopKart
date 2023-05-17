using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Project.IRepository;
using First_Project.Data;

namespace First_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDataController : ControllerBase
    {
        private readonly ICustomerDataRepository icustomerDataRepository;

        public CustomerDataController(ICustomerDataRepository icustomerDataRepository)
        {
            this.icustomerDataRepository = icustomerDataRepository;
        }
        [HttpPost("addCustomerDetails")]

        public async Task<Boolean>addCustomerDetails(CustomerData customerData)
        {
            return await this.icustomerDataRepository.addCoustomerData(customerData);
        }

        [HttpGet("getAllGender")]
        public async Task<List<Gender>> GetGender()
        {
            return await icustomerDataRepository.GetGender();
        }
        [HttpPost("getcustomerbyId")]
        public async Task<Response> getcustomerbyId(SignIn signin)
        {
            return await icustomerDataRepository.getcustomerbyId(signin);
        }

    }
}
