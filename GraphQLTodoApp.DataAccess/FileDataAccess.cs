using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using GraphQLTodoApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GraphQLTodoApp.DataAccess
{
    public class FileDataAccess : IFileDataAccess
    {
        private readonly IConfiguration Configuration;
        private readonly IFileProvider FileProvider;

        public FileDataAccess(IConfiguration configuration, IFileProvider fileProvider)
        {
            this.Configuration = configuration;
            this.FileProvider = fileProvider;
        }

        public ItemModel Find(Guid itemId)
        {
            List<ItemModel> files = this.Read();
            return files.FirstOrDefault(x => x.ItemId == itemId);
        }

        public List<ItemModel> Read()
        {
            IFileInfo file = this.FileProvider.GetFileInfo(this.Configuration.GetSection("DataAccess:FilePath").Value);
            return JsonConvert.DeserializeObject<List<ItemModel>>(File.ReadAllText(file.PhysicalPath));
        }

        public List<ItemModel> Add(ItemModel item)
        {
            item.ItemId = Guid.NewGuid();
            List<ItemModel> items = this.Read();
            items.Add(item);
            this.WriteToFile(items);

            return this.Read();
        }

        public List<ItemModel> Update(ItemModel item)
        {
            List<ItemModel> items = this.Read();
            items.Remove(items.Find(x => x.ItemId == item.ItemId));
            items.Add(item);
            this.WriteToFile(items);

            return this.Read();
        }

        public List<ItemModel> Delete(Guid itemId)
        {
            List<ItemModel> items = this.Read();
            items.Remove(items.Find(x => x.ItemId == itemId));
            this.WriteToFile(items);

            return this.Read();
        }

        private void WriteToFile(List<ItemModel> items)
        {
            IFileInfo file = this.FileProvider.GetFileInfo(this.Configuration.GetSection("DataAccess:FilePath").Value);
            string json = JsonConvert.SerializeObject(items);
            File.WriteAllText(file.PhysicalPath, json);
        }
    }
}
