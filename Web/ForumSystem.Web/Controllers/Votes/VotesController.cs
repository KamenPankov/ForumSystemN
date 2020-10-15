using System.Threading.Tasks;

using ForumSystem.Data.Models;
using ForumSystem.Services.Data;
using ForumSystem.Web.ViewModels.Votes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Web.Controllers.Votes
{
    [ApiController]
    [Route("api/{controller}")]
    public class VotesController : BaseController
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(
            IVotesService votesService,
            UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel inputModel)
        {
            string userId = this.userManager.GetUserId(this.User);
            await this.votesService.VoteAsync(inputModel.PostId, userId, inputModel.IsUpVote);
            int votes = this.votesService.VotesCount(inputModel.PostId);

            return new VoteResponseModel { VotesCount = votes, };
        }
    }
}
