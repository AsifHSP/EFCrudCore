using EntityFrameWorkCodeFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCodeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CurdDbContext crudDbContext;

        public ProductController(CurdDbContext crudDbContext)
        {
            this.crudDbContext = crudDbContext;
        }
        //GetAllProduct
        [HttpGet]

        [Route("GetProducts")]
        public List<Product> GetProducts()
        {
            return crudDbContext.Products.ToList();
        }

        //Get single product data via id
        [HttpGet]

        [Route("GetProduct")]
        public Product GetProduct(int id)
        {
            return crudDbContext.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        //Insert data of Product in Product Table.
        [HttpPost]
        [Route("AddProduct")]
        public string AddProduct(Product product)
        {
            //string response = string.empty;
            crudDbContext.Products.Add(product);
            crudDbContext.SaveChanges();
            return "Product Added";
        }

        //Update the product data in Product Table
        [HttpPut]
        [Route("UpdateProduct")]
        public string UpdateProduct(Product product) 
        {
            crudDbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            crudDbContext.SaveChanges();
            return "Update Product.";
        }

        // Delete Product from Product Table

        [HttpDelete]
        [Route("DeleteProduct")]

        public string DeleteProduct(int id)
        {
            Product product = crudDbContext.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product != null)
            {
                crudDbContext.Products.Remove(product);
                crudDbContext.SaveChanges();
                return "Product Delelted";
            }
            else
            {
                return "No user found.";
            }
        }
    }
}

