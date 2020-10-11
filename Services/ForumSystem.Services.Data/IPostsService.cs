using ForumSystem.Data.Models;
using System.Threading.Tasks;

namespace ForumSystem.Services.Data
{
    public interface IPostsService
    {
        Task<int> AddPostAsync(string title, string content, int categoryId, string userId);

        T GetPostById<T>(int id);
    }
}
