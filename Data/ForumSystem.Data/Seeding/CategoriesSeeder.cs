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

            Tuple<string, string>[] categories =
                {
                new Tuple<string, string>("Coronavirus", "https://comac-medical.com/wp-content/uploads/2020/03/coronavirus-image.jpg"),
                new Tuple<string, string>("Sport", "https://smartcdn.prod.postmedia.digital/nexus/wp-content/uploads/2019/03/Sports-balls-e1585774354763.jpg"),
                new Tuple<string, string>("News", "https://newstravel.bg/wp-content/uploads/2019/08/Marketplace-Lending-News.jpg"),
                new Tuple<string, string>("Programming", "https://learnworthy.net/wp-content/uploads/2019/12/Why-programming-is-the-skill-you-have-to-learn.jpg"),
                new Tuple<string, string>("Cats", "https://media.wired.com/photos/5e1e646743940d0008009167/125:94/w_2038,h_1532,c_limit/Science_Cats-84873657.jpg"),
                new Tuple<string, string>("Dogs", "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQl9RD-pgtKmTaUf04x7QKTtoNX4cF8WhKdtg&usqp=CAU"),
                new Tuple<string, string>("Music", "https://sm.mashable.com/t/mashable_in/photo/default/instagrammusic_2j1u.960.jpg"),
                };

            foreach (Tuple<string, string> category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Item1,
                    Title = category.Item1,
                    ImageUrl = category.Item2,
                });
            }
        }
    }
}
