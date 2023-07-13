using Microsoft.AspNetCore.Mvc;
using EntityFrameWorkCodeFirstApproach.Models;

namespace EntityFrameWorkCodeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly CurdDbContext crudDbContext;

        public ProductCategoryController(CurdDbContext crudDbContext)
        {
            this.crudDbContext = crudDbContext;
        }

           //Get All Product Categories
        [HttpGet]

        [Route("GetProductsCategory")]
        public List<ProductCategory> GetProductsCategory()
        {
            return crudDbContext.ProductCategories.ToList();
        }


        //Get Product Category By Id
        [HttpGet]

        [Route("GetProductCategory")]
        public ProductCategory GetProductCategory(int id)
        {
            return crudDbContext.ProductCategories.Where(x => x.Id == id).FirstOrDefault();
        }

        //Insert category in ProductCategory Table.
        [HttpPost]
        [Route("AddProductCategory")]
        public string AddProductCategory(ProductCategory productCategory)
        {
            crudDbContext.ProductCategories.Add(productCategory);
            crudDbContext.SaveChanges();
            return "Product Category Added Successfully";
        }

        //Update the product category in ProductCategory Table
        [HttpPut]
        [Route("UpdateProductCategory")]
        public string UpdateProductCategory(ProductCategory productCategory)
        {
            crudDbContext.Entry(productCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            crudDbContext.SaveChanges();
            return "Product Category Updated Successfully.";
        }

        // Delete Product Category from ProductCategory Table

        [HttpDelete]
        [Route("DeleteProductCategory")]

        public string DeleteProductCategory(int id)
        {
            ProductCategory productCategory = crudDbContext.ProductCategories.Where(x => x.Id == id).FirstOrDefault();
            if (productCategory != null)
            {
                crudDbContext.ProductCategories.Remove(productCategory);
                crudDbContext.SaveChanges();
                return "Product Category Delelted Successfully";
            }
            else
            {
                return "No user found.";
            }
        }
    }
}
