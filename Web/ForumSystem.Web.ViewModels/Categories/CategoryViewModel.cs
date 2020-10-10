using System.Collections.Generic;

using ForumSystem.Data.Models;
using ForumSystem.Services.Mapping;

namespace ForumSystem.Web.ViewModels.Categories
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }

        public IEnumerable<PostInCategoryViewModel> Posts { get; set; }
    }
}
