using Repositories.Items;
using GraphQL.Types;

namespace ToDoList_task.GraphQL.GraphQLTypes
{
    public class ToDoType : ObjectGraphType<ToDo>
    {
        public ToDoType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Text);
            Field(x => x.Description, nullable: true);
            Field(x => x.Deadline, nullable: true);
            Field(x => x.IsComplete);
            Field(x => x.CategoryId, nullable: true);
        }
    }
}
