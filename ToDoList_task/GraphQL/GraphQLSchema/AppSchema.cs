using GraphQL.Types;
using ToDoList_task.GraphQL.GraphQLQueries;

namespace ToDoList_task.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<ToDoQuery>();
        }
    }
}
