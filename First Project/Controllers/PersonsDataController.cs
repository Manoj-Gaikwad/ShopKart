using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Project.IRepository;
using First_Project.Repository;
using First_Project.Data;

namespace First_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsDataController : ControllerBase
    {
        public readonly IPersonsDataRepositiory ipersonsDataRepositiory;

        public PersonsDataController(IPersonsDataRepositiory ipersonsDataRepositiory)
        {
            this.ipersonsDataRepositiory = ipersonsDataRepositiory;
        }


        [HttpGet("getAllPersonsData")]

        public async Task<List<PersonsData>> GetEmployeeDetails()
        {
            return await ipersonsDataRepositiory.getAllPersons();
        }

        [HttpGet("getPersonById")]

        public async Task<PersonsData> getPersonsById(int id)
        {
            return await ipersonsDataRepositiory.getPersonsById(id);
        }
        [HttpPost("addpersons")]
        public async Task<PersonsData> addPersons(PersonsData personsData)
        {
            return await ipersonsDataRepositiory.addPersons(personsData);
        }
        [HttpPost("updateperson")]
        public async Task<PersonsData> updateperson(PersonsData personsData)
        {
            return await ipersonsDataRepositiory.updatePerson(personsData);
        }
        [HttpDelete("deletperson")]
        public async Task<PersonsData> deletPerson(int id)
        {
            return await ipersonsDataRepositiory.deletPerson(id);
        }
    }
}
