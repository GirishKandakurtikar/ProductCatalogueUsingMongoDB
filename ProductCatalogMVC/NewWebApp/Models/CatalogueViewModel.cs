using System.Collections.Generic;

namespace NewWebApp.Models
{
    public class CatalogueViewModel
    {

        public string selectedCategoryId { get; set; }

        public string NewName { get; set; }
        public Category category { get; set; }

        public List<Category> categories  { get; set; }

        public SubCategory subCategory { get; set; }

        public List<SubCategory> subCategories { get; set; }

        public Product product { get; set; }

        public List<Product> products { get; set; }

        

    }
}