using GraphQL.Types;
using ToDoList_task.GraphQL.GraphQLTypes;
using Repositories.IRepositories;
using GraphQL;

namespace ToDoList_task.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IToDoRepository toDoRep, ICategoryRepository categRep)
        {
            Field<ListGraphType<ToDoType>>(
               "todolist",
               resolve: context => toDoRep.GetList()
           );
            Field<ToDoType>(
                "todoitem",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context =>
                {
                    int id = Convert.ToInt32(context.Arguments["id"]);
                    return toDoRep.Get(id);
                }
            );

            Field<ListGraphType<CategoryType>>(
                "categories", 
                resolve: context => categRep.GetList()
            );

        }
    }
}
