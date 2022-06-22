using GraphQL.Types;

namespace ToDoList_task.GraphQL.GraphQLTypes
{
    public class ToDoInputType : InputObjectGraphType
    {
        public ToDoInputType()
        {
            Name = "toDoInput";
            Field<IdGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("text");
            Field<StringGraphType>("description");
            Field<DateTimeGraphType>("deadline");
            Field<IntGraphType>("categoryId");
            Field<BooleanGraphType>("isComplete");
        }
    }
}
