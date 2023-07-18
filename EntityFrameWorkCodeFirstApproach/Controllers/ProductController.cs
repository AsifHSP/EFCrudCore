using EntityFrameWorkCodeFirstApproach.Dto;
using EntityFrameWorkCodeFirstApproach.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCodeFirstApproach.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CurdDbContext crudDbContext;
        private Response response = new Response();

        public ProductController(CurdDbContext crudDbContext)
        {
            this.crudDbContext = crudDbContext;
        }
        //GetAllProduct
        [HttpGet]

        [Route("GetProducts")]
        public List<Product> GetProducts()
        {
            var data = crudDbContext.Products.Select(x => new Product
            {
                Id=x.Id,
                Name = x.Name,
                ProductCategoryId = x.ProductCategoryId,
                ProductFreshnessName = x.ProductCategory.Name,
                ProductFreshnessId = x.ProductFreshnessId,
                ProductCategoryName = x.ProductFreshness.Name,
                SelectionDate = x.SelectionDate,
                Price = x.Price,
                Comment = x.Comment
            }).ToList();

            return data;
        }

        //Get single product data via id
        [HttpGet]

        [Route("GetProduct")]
        public Product GetProduct(int id)
        {
            var data= crudDbContext.Products.Include("ProductCategory").Include("ProductFreshness").Where(x => x.Id == id).Select(x=> new Product
            {
                Id = x.Id,
                Name=x.Name,
                ProductCategoryId=x.ProductCategoryId,
                ProductFreshnessName=x.ProductCategory.Name,
                ProductFreshnessId=x.ProductFreshnessId,
                ProductCategoryName=x.ProductFreshness.Name,
                SelectionDate=x.SelectionDate,
                Price=x.Price,
                Comment=x.Comment
            }).FirstOrDefault();
            return data;
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
        public Response UpdateProduct( Product product) 
        {
            try
            {
                crudDbContext.Entry(product).State = EntityState.Modified;
                crudDbContext.SaveChanges();
                response.Message = "Product Updated Successfully.";
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
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

