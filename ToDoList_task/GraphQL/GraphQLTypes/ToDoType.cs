using Repositories.Items;
using GraphQL.Types;

namespace ToDoList_task.GraphQL.GraphQLTypes
{
    public class ToDoType : ObjectGraphType<ToDo>
    {
        public ToDoType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the ToDo object.");
            Field(x => x.Text).Description("Text property from the ToDo object.");
            Field(x => x.Description).Description("Description property from the ToDo object.");
            Field(x => x.Deadline).Description("Deadline property from the ToDo object.");
            Field(x => x.IsComplete).Description("IsComplete property from the ToDo object.");
            Field(x => x.CategoryId).Description("CategoryId property from the ToDo object.");
        }
    }
}
