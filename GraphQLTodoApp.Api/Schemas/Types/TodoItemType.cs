using GraphQL.Types;
using GraphQLTodoApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTodoApp.Api.Schemas.Types
{
    public class TodoItemType : ObjectGraphType<ItemModel>
    {
        public TodoItemType()
        {
            Field(x => x.ItemId, type: typeof(IdGraphType)).Name("id");
            Field(x => x.Name).Name("name");
            Field(x => x.Priority).Name("priority");
            Field(x => x.Description).Name("description");
            Field(x => x.Contents).Name("contents");
            Field(x => x.Category).Name("category");
            Field(x => x.CreatedBy).Name("createdBy");
            Field(x => x.CreatedDate, type: typeof(DateTimeGraphType)).Name("createDate");
            Field(x => x.LastModifiedDate, type: typeof(DateTimeGraphType)).Name("modifiedDate");
        }
    }
}
