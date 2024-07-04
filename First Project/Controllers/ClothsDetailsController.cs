using First_Project.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Project.Data;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet("getClothsData")]
        //[Authorize(Roles  = "admin")]
        public async Task<List<ClothsData>> getAllClothsDeta()
        {
            return await iclothsDetailsRepository.getAllCloths();
        }
        [HttpPost("AddClothsData")]
        public async Task<Object> addClothsData(ClothsData clothsData)
        {
            return await iclothsDetailsRepository.addClothsData(clothsData);
        }
        [HttpGet("getAllClothsData")]
        public async Task<List<ClothsData>> getAllClothsData()
        {
            return await iclothsDetailsRepository.getAllClothsData();
        }
    }
}
