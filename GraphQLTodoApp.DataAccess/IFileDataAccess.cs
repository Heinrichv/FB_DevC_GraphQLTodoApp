using GraphQLTodoApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTodoApp.DataAccess
{
    public interface IFileDataAccess
    {
        ItemModel Find(Guid itemId);

        List<ItemModel> Read();

        List<ItemModel> Add(ItemModel item);

        List<ItemModel> Update(ItemModel item);

        List<ItemModel> Delete(Guid itemId);
    }
}
