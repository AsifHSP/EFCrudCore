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
    }
}

