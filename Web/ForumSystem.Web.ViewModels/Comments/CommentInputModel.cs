﻿namespace ForumSystem.Web.ViewModels.Comments
{
    public class CommentInputModel
    {
        public int PostId { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public int? ParentId { get; set; }
    }
}
