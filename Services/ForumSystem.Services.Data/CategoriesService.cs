using System.Collections.Generic;
using System.Linq;

using ForumSystem.Data.Common.Repositories;
using ForumSystem.Data.Models;
using ForumSystem.Services.Mapping;

namespace ForumSystem.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        private IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> repository)
        {
            this.categoriesRepository = repository;
        }

        public T CategoryByName<T>(string name)
        {
            T category = this.categoriesRepository.All()
                .Where(c => c.Name == name).To<T>()
                .FirstOrDefault();

            return category;
        }

        public IEnumerable<T> GetAll<T>(int? count)
        {
            IQueryable<Category> query = this.categoriesRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToArray();
        }
    }
}
