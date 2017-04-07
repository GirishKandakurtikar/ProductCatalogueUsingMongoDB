using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIToMongoDB.Models;

namespace WebAPIToMongoDB.Controllers
{

    [Route("api/Category")]
    public class CategoryAPIController : Controller
    {
        DataAccess objds;

        public CategoryAPIController(DataAccess d)
        {
            objds = d;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {

            return objds.GetCategories();
        }
        [HttpGet("~/api/Category/GetCategory/{id}")]
        public IActionResult GetCategory(string id)
        {
            var category = objds.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return new ObjectResult(category);
        }

        [HttpPost("~/api/Category/PostCategory")]
        public IActionResult PostCategory([FromBody]Category c)
        {
            objds.CreateCategory(c);
           
            return new ObjectResult(c);
        }
        [HttpPut("~/api/Category/PutCategory/{id}")]
        public IActionResult PutCategory(string id, [FromBody]Category c)
        {
    

            var category = objds.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            objds.UpdateCategory(id, c);
            return new OkResult();
        }

        [HttpDelete("~/api/Category/DeleteCategory/{id}")]
        public IActionResult DeleteCategory(string id)
        {
            var category = objds.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            objds.RemoveCategory(category.Id);
            return new OkResult();
        }
    }


    
}
