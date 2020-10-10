using System.Diagnostics;
using System.Linq;

using ForumSystem.Data.Common.Repositories;
using ForumSystem.Data.Models;
using ForumSystem.Services.Data;
using ForumSystem.Services.Mapping;
using ForumSystem.Web.ViewModels;
using ForumSystem.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

using IndexViewModel = ForumSystem.Web.ViewModels.Home.IndexViewModel;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Categories = this.categoriesService.GetAll<IndexCategoryViewModel>();

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
