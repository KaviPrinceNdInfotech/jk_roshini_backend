using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.JkDb;
using Jk_Roshni.Models.Service;
using Jk_Roshni.Models.Entities;
namespace Jk_Roshni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct productRepo;
        public ProductController(IProduct _productRepo)
        {
            productRepo = _productRepo;
        }
        [HttpPost("[action]")]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                 bool isvalid= productRepo.AddProduct(product);
                if(isvalid)
                {
                    return Ok(new { status = 200, message = "Product Add SucessFully" });
                }
                else
                {
                    return BadRequest("Product Not Save");
                }
                  
            }
            catch
            {
                return BadRequest("Server Error");
            }
        }

        [HttpGet("[action]")]
        public IEnumerable<Product> ProductList()
        {
            return productRepo.GetProducts();
        }
    }
}
