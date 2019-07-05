using GraphQL.Types;
using GraphQLTodoApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTodoApp.Api.Schemas.Types
{
    public class TodoItemInputType : ObjectGraphType<ItemModel>
    {
        public TodoItemInputType()
        {
            Name = "TodoInput";
            Field<IdGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("priority");
            Field<StringGraphType>("description");
            Field<StringGraphType>("contents");
            Field<StringGraphType>("category");
            Field<StringGraphType>("createdBy");
            Field<DateTimeGraphType>("createDate");
            Field<DateTimeGraphType>("modifiedDate");

        }
    }
}
