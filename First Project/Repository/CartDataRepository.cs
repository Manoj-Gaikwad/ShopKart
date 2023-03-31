using First_Project.Data;
using First_Project.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Repository
{
    public class CartDataRepository: ICartDataRepository
    {
        private readonly DBConnection dBConnection;

        public CartDataRepository(DBConnection dBConnection)
        {
            this.dBConnection = dBConnection;
        }


        public async Task<List<CartData>>getAllCartData()
        {
            return await dBConnection.cart.ToListAsync();
        }

        public async Task<Boolean> removeItem(int id)
        {
            CartData data = await dBConnection.cart.SingleOrDefaultAsync(x => x.id == id);

            if (data != null)
            {
                dBConnection.Remove(data);
                await dBConnection.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
             
        }
       

        public async Task<Boolean>addCartData(CartData cartData)
        {
            if(cartData!=null)
            {
                CartData cart = new CartData()
                {
                    pid = cartData.pid,
                    ptype = cartData.pname,
                    pname = cartData.pname,
                    psize = cartData.psize,
                    pcolor = cartData.pcolor,
                    pquantity = cartData.pquantity,
                    pprice = cartData.pprice,
                    newprice=cartData.newprice,
                    pimage = cartData.pimage
                };
                await dBConnection.AddAsync(cart);
                await dBConnection.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            };
        }



        public async Task<Boolean> updateCartData(CartData cartData)
        {
            CartData cartData1 = await dBConnection.cart.SingleOrDefaultAsync(x => x.id == cartData.id);

            if (cartData1 != null)
            {
                cartData1.pid = cartData.pid;
                cartData1.ptype = cartData.pname;
                cartData1.pname = cartData.pname;
                cartData1.psize = cartData.psize;
                cartData1.pcolor = cartData.pcolor;
                cartData1.pquantity = cartData.pquantity;
                cartData1.pprice = cartData.pprice;
                cartData1.newprice = cartData.newprice;
                cartData1.pimage = cartData.pimage;

                await dBConnection.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            };
        }
        
    }
}
