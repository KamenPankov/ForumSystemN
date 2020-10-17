using System;

using ForumSystem.Services.Data;
using ForumSystem.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Web.Controllers.Categories
{
    public class CategoriesController : Controller
    {
        private const int ItemsPerPage = 5;
        private readonly ICategoriesService categoriesService;
        private readonly IPostsService postsService;

        public CategoriesController(
            ICategoriesService categoriesService,
            IPostsService postsService)
        {
            this.categoriesService = categoriesService;
            this.postsService = postsService;
        }

        public IActionResult CategoryByName(string name, int page)
        {
            if (page < 1)
            {
                page = 1;
            }

            CategoryViewModel viewModel = this.categoriesService.CategoryByName<CategoryViewModel>(name);
            viewModel.ForumPosts =
                this.postsService.GetPostsByCategoryId<PostInCategoryViewModel>(
                    viewModel.Id, (page - 1) * ItemsPerPage, ItemsPerPage);
            viewModel.TotalPages = (int)Math.Ceiling((double)this.postsService.PostsCountByCategory(viewModel.Id) / ItemsPerPage);
            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }
    }
}
