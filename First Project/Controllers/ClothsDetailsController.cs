using First_Project.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Project.Data;

namespace First_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothsDetailsController : ControllerBase
    {
        private readonly IClothsDetailsRepository iclothsDetailsRepository;

        public ClothsDetailsController(IClothsDetailsRepository iclothsDetailsRepository)
        {
            this.iclothsDetailsRepository = iclothsDetailsRepository;
        }

        [HttpGet("getClothsDeta")]
        public async Task<List<ClothsData>> getAllClothsDeta()
        {
            return await iclothsDetailsRepository.getAllCloths();
        }
        [HttpGet("getAllClothsData")]
        public async Task<List<ClothsAllData>> getAllClothsData()
        {
            return await iclothsDetailsRepository.getAllClothsData();
        }


    }
}
