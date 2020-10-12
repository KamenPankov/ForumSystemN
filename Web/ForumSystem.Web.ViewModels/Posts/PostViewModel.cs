using System;

using ForumSystem.Data.Models;
using ForumSystem.Services.Mapping;
using Ganss.XSS;

namespace ForumSystem.Web.ViewModels.Posts
{
    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public DateTime CreatedOn{ get; set; }

        public string UserUserName { get; set; }

        public int CategoryId { get; set; }
    }
}
