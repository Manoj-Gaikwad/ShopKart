using First_Project.Data;
using First_Project.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Repository
{
    public class ClothsDetailsRepository: IClothsDetailsRepository
    {
        private readonly DBConnection dBConnection;

        public ClothsDetailsRepository(DBConnection dBConnection)
        {
            this.dBConnection = dBConnection;
        }
        public async Task<List<ClothsData>> getAllCloths()
        {
            return await dBConnection.cloths.ToListAsync();
        }

        public async Task<List<ClothsAllData>> getAllClothsData()
        {
            var data = await (from cloths in dBConnection.cloths
                              join subimage in dBConnection.subclothimages
                              on cloths.pid equals subimage.pid
                              where cloths.pid == subimage.pid
                              select new ClothsAllData()
                              {
                                  pid = cloths.pid,
                                  ptype = cloths.ptype,
                                  pname = cloths.pname,
                                  pprice = cloths.pprice,
                                  pcolor = cloths.pcolor,
                                  pdes = cloths.pdes,
                                  pimage = cloths.pimage,
                                  scimage1=subimage.scimage1,
                                  scimage2 = subimage.scimage2,
                                  scimage3 = subimage.scimage3

                              }).ToListAsync();
            return data;
        }
    }
}
