using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furniture_store.Database
{
    class RequestsDB
    {
        private static shopEntities1 objDB = new shopEntities1();

        public static List<Products> GetAllProducts()
        {
            return objDB.Products.ToList();
        }
        public static List<Products> GetProductsWithDiscound(int StartDiscound, int EndDiscound)
        {
            return objDB.Products.Where(
                product => product.discount >= StartDiscound && product.discount <= EndDiscound
                ).ToList();
        }
    }
}
