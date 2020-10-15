using ForumSystem.Data.Common.Repositories;
using ForumSystem.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ForumSystem.Services.Data
{
    public class VotesService : IVotesService
    {
        private IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public async Task VoteAsync(int postId, string userId, bool isUpVote)
        {
            Vote vote = this.votesRepository.All()
                .FirstOrDefault(v => v.PostId == postId && v.UserId == userId);

            if (vote != null)
            {
                vote.VoteType = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    PostId = postId,
                    UserId = userId,
                    VoteType = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await this.votesRepository.AddAsync(vote);
            }

            await this.votesRepository.SaveChangesAsync();
        }

        public int VotesCount(int postId)
        {
            return this.votesRepository.All()
                .Where(v => v.PostId == postId)
                .Sum(v => (int)v.VoteType);
        }
    }
}
