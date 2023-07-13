using Microsoft.AspNetCore.Mvc;
using EntityFrameWorkCodeFirstApproach.Models;


namespace EntityFrameWorkCodeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFreshnessController : ControllerBase
    {
        private readonly CurdDbContext crudDbContext;

        public ProductFreshnessController(CurdDbContext crudDbContext)
        {
            this.crudDbContext = crudDbContext;
        }

        //Get All Product Freshness
        [HttpGet]

        [Route("GetProductsFreshness")]
        public List<ProductFreshness> GetProductsFreshness()
        {
            return crudDbContext.ProductFreshnesses.ToList();
        }

        //Get Product Freshness By Id
        [HttpGet]

        [Route("GetProductFreshness")]
        public ProductFreshness GetProductFreshness(int id)
        {
            return crudDbContext.ProductFreshnesses.Where(x => x.Id == id).FirstOrDefault();
        }

        //Insert ProductFreshness in ProductFreshness Table.
        [HttpPost]

        [Route("AddProductFreshness")]
        public string AddProductFreshness(ProductFreshness productFreshness)
        {
            crudDbContext.ProductFreshnesses.Add(productFreshness);
            crudDbContext.SaveChanges();
            return "Product Freshness Added Successfully";
        }

        //Update the product Freshness in ProductFreshness Table
        [HttpPut]

        [Route("UpdateProductFreshness")]
        public string UpdateProductFreshness(ProductFreshness productFreshness)
        {
            crudDbContext.Entry(productFreshness).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            crudDbContext.SaveChanges();
            return "Product Freshness Updated Successfully.";                                                                                                  
        }

        //Delete the product Freshness from the ProductFreshness Table
        [HttpDelete]

        [Route("DeleteProductFreshness")]
        public string DeleteProductFreshness(int id)
        {
            ProductFreshness productFreshness = crudDbContext.ProductFreshnesses.Where(x => x.Id == id).FirstOrDefault();
            if (productFreshness != null)
            {
                crudDbContext.ProductFreshnesses.Remove(productFreshness);
                crudDbContext.SaveChanges();
                return "Product Freshness Delelted Successfully";
            }
            else
            {
                return "No freshness found.";
            }
        }
    }
}
