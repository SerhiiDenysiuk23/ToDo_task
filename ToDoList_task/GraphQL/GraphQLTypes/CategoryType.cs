using Repositories.Items;
using GraphQL.Types;

namespace ToDoList_task.GraphQL.GraphQLTypes
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the Category object.");
            Field(x => x.Name).Description("Name property from the Category object.");
        }
    }
}
