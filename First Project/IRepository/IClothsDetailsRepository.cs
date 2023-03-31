using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace First_Project.IRepository
{
    public interface IClothsDetailsRepository
    {
        Task<List<ClothsData>> getAllCloths();
        Task<Object> addClothsData(ClothsAllData clothsData);
        Task<List<ClothsAllData>> getAllClothsData();
    }
}
