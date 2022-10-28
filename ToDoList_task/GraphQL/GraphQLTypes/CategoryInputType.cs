using GraphQL.Types;

namespace ToDoList_task.GraphQL.GraphQLTypes
{
    public class CategoryInputType : InputObjectGraphType
    {
        public CategoryInputType()
        {
            Name = "categoryInput";
            Field<IdGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
