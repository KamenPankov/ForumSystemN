using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using ForumSystem.Data.Models;
using ForumSystem.Services.Mapping;
using Ganss.XSS;

namespace ForumSystem.Web.ViewModels.Posts
{
    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public DateTime CreatedOn { get; set; }

        public string UserUserName { get; set; }

        public int CategoryId { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<CommentInPostViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(d => d.VotesCount, options => options.MapFrom(s => s.Votes.Sum(v => (int)v.VoteType)));
        }
    }
}
