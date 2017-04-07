using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIToMongoDB.Models;
using MongoDB.Bson;

namespace WebAPIToMongoDB.Controllers
{

    [Route("api/SubCategory")]
    public class SubCategoryAPIController : Controller
    {
        DataAccess objds;

        public SubCategoryAPIController(DataAccess d)
        {
            objds = d;
        }

        [HttpGet]
        public IEnumerable<SubCategory> GetSubCategory()
        {
            
            return objds.GetSubCategories();
        }
        [HttpGet("~/api/SubCategory/GetSubCategory/{id}")]
        public IActionResult GetSubCategory(string id)
        {
            var subCategory = objds.GetSubCategory(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            return new ObjectResult(subCategory);
        }

        [HttpPost("~/api/SubCategory/PostSubCategory")]
        public IActionResult PostSubCategory([FromBody]SubCategory sc)
        {
            objds.CreateSubCategory(sc);

            return new OkResult();
        }
        [HttpPut("~/api/SubCategory/PutSubCategory/{id}")]
        public IActionResult PutSubCategory(string id, [FromBody]SubCategory sc)
        {
            var subCategory = objds.GetSubCategory(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            objds.UpdateSubCategory(id, sc);
            return new OkResult();
        }

        [HttpDelete("~/api/SubCategory/DeleteSubCategory/{id}")]
        public IActionResult DeleteSubCategory(string id)
        {
            var subCategory = objds.GetSubCategory(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            objds.RemoveSubCategory(subCategory.Id);
            return new OkResult();
        }
    }


    
}
