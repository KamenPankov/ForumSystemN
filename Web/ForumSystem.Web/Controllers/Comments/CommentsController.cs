using System.Threading.Tasks;

using ForumSystem.Data.Models;
using ForumSystem.Services.Data;
using ForumSystem.Web.ViewModels.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Web.Controllers.Comments
{
    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(
            ICommentsService commentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CommentInputModel inputModel)
        {
            string userId = this.userManager.GetUserId(this.User);
            int commentId = await this.commentsService.Create(inputModel.PostId, userId, inputModel.Content, inputModel.ParentId);

            return this.RedirectToAction("PostById", "Posts", new { id = inputModel.PostId });
        }
    }
}
