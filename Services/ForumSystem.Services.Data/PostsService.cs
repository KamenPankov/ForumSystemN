using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ForumSystem.Data.Common.Repositories;
using ForumSystem.Data.Models;
using ForumSystem.Services.Mapping;

namespace ForumSystem.Services.Data
{
    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PostsService(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task<int> AddPostAsync(string title, string content, int categoryId, string userId)
        {
            Post post = new Post
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                UserId = userId,
            };

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();

            return post.Id;
        }

        public T GetPostById<T>(int id)
        {
            T post = this.postRepository.All()
                .Where(p => p.Id == id)
                .To<T>()
                .FirstOrDefault();

            return post;
        }

        public IEnumerable<T> GetPostsByCategoryId<T>(int categoryId, int skip = 0, int? take = null)
        {
            IQueryable<Post> query = this.postRepository.All()
                .Where(p => p.CategoryId == categoryId)
                .OrderByDescending(p => p.CreatedOn)
                .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToArray();
        }

        public int PostsCountByCategory(int categoryId)
        {
            return this.postRepository.All()
                .Where(p => p.CategoryId == categoryId)
                .Count();
        }
    }
}
