using Repositories.Items;

namespace Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        void Delete(int id);
        Category Get(int id);
        List<Category> GetList();
    }
}
