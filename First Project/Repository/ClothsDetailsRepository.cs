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

        public async Task<Object>addClothsData(ClothsAllData clothsData)
        {
            if(clothsData!=null)
            {
                ClothsAllData clothsData1 = new ClothsAllData()
                {
                    ptype = clothsData.ptype,
                    pname = clothsData.pname,
                    pprice = clothsData.pprice,
                    pcolor = clothsData.pcolor,
                    pdes = clothsData.pdes,
                    psize = clothsData.psize,
                    pquantity = clothsData.pquantity,
                    pimage=clothsData.pimage,
                    scimage1=clothsData.scimage1,
                    scimage2=clothsData.scimage2,
                    scimage3=clothsData.scimage3
                    
                };
                await dBConnection.AddAsync(clothsData1);
                await dBConnection.SaveChangesAsync();

            }
            Response r1 = new Response();
            r1.message = "Success";

            return r1;
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
                                  psize=cloths.psize,
                                  pquantity=cloths.pquantity,
                                  pimage = cloths.pimage,
                                  scimage1=subimage.scimage1,
                                  scimage2 = subimage.scimage2,
                                  scimage3 = subimage.scimage3

                              }).ToListAsync();
            return data;
        }
    }
}
