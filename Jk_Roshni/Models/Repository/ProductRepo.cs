using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.Entities;
using Jk_Roshni.Models.Service;
using Jk_Roshni.Models.JkDb;
namespace Jk_Roshni.Models.Repository
{
    public class ProductRepo : IProduct
    {
        private JkDbContext jkdbcontext;
        public ProductRepo(JkDbContext _jkDbContext)
        {
            jkdbcontext = _jkDbContext;
        }
        public bool AddProduct(Product product)
        {
            try
            {
                Product emp = new Product()
                {
                      Name=product.Name
                };
                jkdbcontext.products.Add(emp);
               jkdbcontext.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Server Error");
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return jkdbcontext.products.ToList();
        }
    }
}
