using CategoryService.Models;
using CategoryService.Repository;

namespace CategoryService.Services
{
    public class CategoryServiceClass
    {
        private readonly ICategoryRepository _repository;

        public CategoryServiceClass(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Category>> GetAll() => _repository.GetAll();

        public Task<Category> GetById(int id) => _repository.GetById(id);

        public Task<Category> Add(Category category) => _repository.Add(category);

        public Task<Category> Update(Category category) => _repository.Update(category);

        public Task<bool> Delete(int id) => _repository.Delete(id);
    }
}
