using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTodoApp.Api.Schemas
{
    public class TodoItemSchema : Schema
    {
        public TodoItemSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TodoItemQuery>();
        }
    }
}
