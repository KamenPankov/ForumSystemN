using ForumSystem.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Data.Models
{
    public class Vote : BaseModel<int>
    {
        public VoteType VoteType { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
