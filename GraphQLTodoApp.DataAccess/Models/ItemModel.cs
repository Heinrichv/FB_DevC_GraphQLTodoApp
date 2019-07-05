using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTodoApp.DataAccess.Models
{
    public class ItemModel
    {
        public Guid ItemId { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Priority { get; set; }

        public string Description { get; set; }

        public string Contents { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
