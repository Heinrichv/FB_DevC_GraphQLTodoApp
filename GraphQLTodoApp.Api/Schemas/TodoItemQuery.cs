using GraphQL.Types;
using GraphQLTodoApp.Api.Schemas.Types;
using GraphQLTodoApp.DataAccess;
using GraphQLTodoApp.DataAccess.Models;
using System;

namespace GraphQLTodoApp.Api.Schemas
{
    public class TodoItemQuery : ObjectGraphType
    {
        public TodoItemQuery(IFileDataAccess fileDataAccess)
        {
            Field<ListGraphType<TodoItemType>>("all", resolve: ctx =>
            {
                return fileDataAccess.Read();
            });

            Field<TodoItemType>("find", arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }), resolve: ctx =>
            {
                return fileDataAccess.Find(ctx.GetArgument<Guid>("id"));
            });

            Field<ListGraphType<TodoItemType>>("delete", arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }), resolve: ctx =>
            {
                return fileDataAccess.Delete(ctx.GetArgument<Guid>("id"));
            });
        }
    }
}
