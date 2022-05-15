using Repositories.Items;

namespace ToDoList_task.Models
{
    public class ViewModel
    {
        public IEnumerable<ToDo> ToDoList { get; set; }
        public List<Category> Categories { get; set; }
        public Category Category { get; set; }

        public ToDo ToDoItem { get; set; }
    }
}
