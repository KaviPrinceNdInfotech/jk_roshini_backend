using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.Entities;
namespace Jk_Roshni.Models.Service
{
   public interface IProduct
    {
        IEnumerable<Product> GetProducts();

        //Product GetProduct(int id);
        public bool AddProduct(Product product);
        //void UpdateProduct(Product product);
        //void DeleteProduct(int id);
    }
}
