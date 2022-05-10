using Repositories.Items;

namespace Repositories.IRepositories
{
    public interface IToDoRepository
    {
        void Create(ToDo toDo);
        void Delete(int id);
        ToDo Get(int id);
        List<ToDo> GetList();
        void Update(ToDo toDo);
        void UpdateState(ToDo toDo);
    }
}
