using ForumSystem.Services.Data;
using ForumSystem.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Web.Controllers.Categories
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult CategoryByName(string name)
        {
            CategoryViewModel viewModel = this.categoriesService.CategoryByName<CategoryViewModel>(name);

            return this.View(viewModel);
        }
    }
}
