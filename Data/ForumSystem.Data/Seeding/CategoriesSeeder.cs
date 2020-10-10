using System;
using System.Threading.Tasks;

using ForumSystem.Data.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace ForumSystem.Data.Seeding
{
    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            (string Name, string ImageUrl)[] categories =
                {
                (Name: "Coronavirus", ImageUrl: "https://comac-medical.com/wp-content/uploads/2020/03/coronavirus-image.jpg"),
                (Name: "Sport", ImageUrl: "https://smartcdn.prod.postmedia.digital/nexus/wp-content/uploads/2019/03/Sports-balls-e1585774354763.jpg"),
                (Name: "News", ImageUrl: "https://newstravel.bg/wp-content/uploads/2019/08/Marketplace-Lending-News.jpg"),
                (Name: "Programming", ImageUrl: "https://learnworthy.net/wp-content/uploads/2019/12/Why-programming-is-the-skill-you-have-to-learn.jpg"),
                (Name: "Cats", ImageUrl: "https://media.wired.com/photos/5e1e646743940d0008009167/125:94/w_2038,h_1532,c_limit/Science_Cats-84873657.jpg"),
                (Name: "Dogs", ImageUrl: "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQl9RD-pgtKmTaUf04x7QKTtoNX4cF8WhKdtg&usqp=CAU"),
                (Name: "Music", ImageUrl: "https://sm.mashable.com/t/mashable_in/photo/default/instagrammusic_2j1u.960.jpg"),
                };

            foreach ((string Name, string ImageUrl) category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    Title = category.Name,
                    ImageUrl = category.ImageUrl,
                });
            }
        }
    }
}
