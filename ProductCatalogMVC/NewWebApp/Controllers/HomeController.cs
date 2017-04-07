using Newtonsoft.Json;
using NewWebApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewWebApp.Controllers
{
    public class HomeController : Controller
    {
        CatalogueViewModel catalogue;
        HttpClient client;
        //The URL of the WEB API Service

        string url = "http://localhost:51278/api/Category";

        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: 
        public async Task<ActionResult> Index()
        {
            catalogue = new CatalogueViewModel();

            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var cats = JsonConvert.DeserializeObject<List<Models.Category>>(responseData);

                catalogue.categories = cats;

                return View(catalogue);
            }
            return View("Error");
        }


        public async Task<ActionResult> EditCategory()
        {

            catalogue = new CatalogueViewModel();

            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var cats = JsonConvert.DeserializeObject<List<Models.Category>>(responseData);

                catalogue.categories = cats;

                return View("EditCategory", catalogue);
            }
            return View("Error");
        }


        public async Task<ActionResult> DeleteCategory()
        {
           
            catalogue = new CatalogueViewModel();

            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var cats = JsonConvert.DeserializeObject<List<Models.Category>>(responseData);

                catalogue.categories = cats;

                return View("DeleteCategory", catalogue);
            }
            return View("Error");
        }

        public ActionResult AddCategory()
        {
            ViewBag.Title = "Add Category";

            return View();
        }

        public async Task<ActionResult> CreateCategory(CatalogueViewModel catalogueViewModel)
        {
            Category cat = catalogueViewModel.category;

            cat.Id = Guid.NewGuid().ToString();

            url = "http://localhost:51278/api/Category/PostCategory";

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, cat);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");

        }



        //The PUT Method

        public async Task<ActionResult> UpdateCategory(CatalogueViewModel catalog)
        {
            Category cat = new Category();

            cat.Id = catalog.selectedCategoryId;
            cat.Name = catalog.NewName;

            url = "http://localhost:51278/api/Category/PutCategory";

            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + cat.Id, cat);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
        
        //The DELETE method
        //[HttpDelete]
        public async Task<ActionResult> DelCategory(CatalogueViewModel catalog)
        {
            url = "http://localhost:51278/api/Category/DeleteCategory";

            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + catalog.selectedCategoryId);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }



        public ActionResult Error()
        {
            ViewBag.Title = "Error Page";

            return View();
        }

        



    }
}
