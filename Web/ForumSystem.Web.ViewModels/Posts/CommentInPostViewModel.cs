﻿using System;

using ForumSystem.Data.Models;
using ForumSystem.Services.Mapping;
using Ganss.XSS;

namespace ForumSystem.Web.ViewModels.Posts
{
    public class CommentInPostViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public DateTime CreatedOn { get; set; }

        public string UserUserName { get; set; }
    }
}
