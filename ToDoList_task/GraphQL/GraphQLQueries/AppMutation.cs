using GraphQL.Types;
using ToDoList_task.GraphQL.GraphQLTypes;
using Repositories.IRepositories;
using Repositories.Items;
using GraphQL;

namespace ToDoList_task.GraphQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IToDoRepository toDoRep, ICategoryRepository categRep)
        {
            Field<ToDoType>(
                "createToDo",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ToDoInputType>> { Name = "toDo" }),
                resolve: context =>
                {
                    ToDo toDo = context.GetArgument<ToDo>("toDo");
                    toDoRep.Create(toDo);
                    return toDo;
                }
            );

            Field<StringGraphType>(
                "deleteToDo",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "toDoId" }),
                resolve: context =>
                {
                    int toDoId = Convert.ToInt32(context.Arguments["toDoId"]);
                    if (toDoRep.Get(toDoId) == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find toDo in db."));
                        return null;

                    }
                    toDoRep.Delete(toDoId);
                    return $"The ToDo with the id: {toDoId} has been successfully deleted from db.";
                }
            );

            Field<ToDoType>(
                "updateToDo",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<ToDoInputType>> { Name = "toDo" }),
                resolve: context =>
                {
                    ToDo toDo = context.GetArgument<ToDo>("toDo");
                    toDoRep.Update(toDo);
                    return toDo;
                }
            );

            Field<CategoryType>(
                "createCategory",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CategoryInputType>> { Name = "category" }),
                resolve: context =>
                {
                    Category categ = context.GetArgument<Category>("category");
                    categRep.Create(categ);
                    return categ;
                }
            );

            Field<StringGraphType>(
                "deleteCategory",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "categoryId" }),
                resolve: context =>
                {
                    int categId = Convert.ToInt32(context.Arguments["categoryId"]);
                    if (categRep.Get(categId) == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Category in db."));
                        return null;

                    }
                    categRep.Delete(categId);
                    return $"The Category with the id: {categId} has been successfully deleted from db.";
                }
            );
        }
    }
}
