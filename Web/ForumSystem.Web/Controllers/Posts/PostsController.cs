﻿using System.Collections.Generic;
using System.Threading.Tasks;

using ForumSystem.Data.Models;
using ForumSystem.Services.Data;
using ForumSystem.Web.ViewModels.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Web.Controllers.Posts
{
    public class PostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(
            IPostsService postsService,
            ICategoriesService categoriesService,
            UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        public IActionResult PostById(int id)
        {
            PostViewModel viewModel = this.postsService.GetPostById<PostViewModel>(id);

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            IEnumerable<DropdownCategoryViewModel> categories = this.categoriesService.GetAll<DropdownCategoryViewModel>();
            PostCreateViewModel viewModel = new PostCreateViewModel
            {
                Categories = categories,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            int postId = await this.postsService.AddPostAsync(input.Title, input.Content, input.CategoryId, user.Id);

            return this.RedirectToAction("PostById", new { id = postId });
        }
    }
}
