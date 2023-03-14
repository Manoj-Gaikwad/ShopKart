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
    public class ShoesDetailsController : ControllerBase
    {
        private readonly IShoesDetailsRepository _shoesDetailsRepository;
        public ShoesDetailsController(IShoesDetailsRepository shoesDetailsRepository)
        {
            _shoesDetailsRepository = shoesDetailsRepository;
        }

    [HttpGet("getAllShoesData")]

    public async Task<List<ShoesData>> getAllShoesData()
        {
            return await _shoesDetailsRepository.GetShoesData();
        }
        [HttpGet("getShoesAllData")]

        public async Task<List<ShoesAllData>> getShoesAllData()
        {
            return await _shoesDetailsRepository.getShoesAllDAta();
        }
    }
}
