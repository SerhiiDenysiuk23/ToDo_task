using Repositories.Items;
using GraphQL.Types;

namespace ToDoList_task.GraphQL.GraphQLTypes
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Name);
        }
    }
}
