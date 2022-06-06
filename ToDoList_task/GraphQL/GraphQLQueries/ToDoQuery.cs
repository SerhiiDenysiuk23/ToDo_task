using GraphQL.Types;
using ToDoList_task.GraphQL.GraphQLTypes;
using Repositories.IRepositories;
using GraphQL;

namespace ToDoList_task.GraphQL.GraphQLQueries
{
    public class ToDoQuery : ObjectGraphType
    {
        public ToDoQuery(IToDoRepository repository)
        {
            Field<ListGraphType<ToDoType>>(
               "todolist",
               resolve: context => repository.GetList()
           );
            Field<ToDoType>(
                "todoitem",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id"}),
                resolve: context =>
                {
                    int id = int.Parse(context.GetArgument<string>("id"));
                    return repository.Get(id);
                }
            );

        }
    }
}
