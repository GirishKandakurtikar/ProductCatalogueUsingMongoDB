using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIToMongoDB.Models;

namespace WebAPIToMongoDB.Controllers
{

    [Route("api/Product")]
    public class ProductAPIController : Controller
    {
        DataAccess objds;

        public ProductAPIController(DataAccess d)
        {
            objds = d;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return objds.GetProducts();
        }


        [HttpGet("~/api/Product/GetProduct/{id}")]
        public IActionResult GetProduct(string id)
        {
            var product = objds.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }

        [HttpPost("~/api/Product/PostProduct")]
        public IActionResult PostProduct([FromBody]Product p)
        {
            objds.CreateProduct(p);
    
            return new ObjectResult(p);
        }
        [HttpPut("~/api/Product/PutProduct/{id}")]
        public IActionResult PutProduct(string id, [FromBody]Product p)
        {
            
            var product = objds.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            objds.UpdateProduct(id, p);
            return new OkResult();
        }

        [HttpDelete("~/api/Product/DeleteProduct/{id}")]
        public IActionResult DeleteProduct(string id)
        {
            var product = objds.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            objds.RemoveProduct(product.Id);
            return new OkResult();
        }
    }


    
}
