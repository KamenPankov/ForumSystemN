using System.Threading.Tasks;

using ForumSystem.Data.Common.Repositories;
using ForumSystem.Data.Models;

namespace ForumSystem.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task<int> Create(int postId, string userId, string content, int? parentId = null)
        {
            Comment comment = new Comment
            {
                PostId = postId,
                UserId = userId,
                Content = content,
                ParentId = parentId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();

            return comment.Id;
        }
    }
}
