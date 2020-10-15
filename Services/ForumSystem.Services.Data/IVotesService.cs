using System.Threading.Tasks;

namespace ForumSystem.Services.Data
{
    public interface IVotesService
    {
        int VotesCount(int postId);

        Task VoteAsync(int postId, string userId, bool isUpVote);
    }
}
