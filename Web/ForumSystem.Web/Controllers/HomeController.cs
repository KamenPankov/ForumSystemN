using System.Diagnostics;
using System.Linq;

using ForumSystem.Data;
using ForumSystem.Web.ViewModels;
using ForumSystem.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

using IndexViewModel = ForumSystem.Web.ViewModels.Home.IndexViewModel;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Categories = this.dbContext.Categories.Select(x => new IndexCategoryViewModel
            {
                Name = x.Name,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
            }).ToArray();

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
