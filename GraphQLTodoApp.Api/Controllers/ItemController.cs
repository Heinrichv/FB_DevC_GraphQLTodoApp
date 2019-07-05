using GraphQLTodoApp.DataAccess;
using GraphQLTodoApp.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace GraphQLTodoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IFileDataAccess FileDataAccess;

        public ItemController(IFileDataAccess fileDataAccess)
        {
            this.FileDataAccess = fileDataAccess;
        }

        [HttpPost]
        [SwaggerResponse(200, type: typeof(List<ItemModel>))]
        public IActionResult Post([FromBody] ItemModel request)
        {
            this.FileDataAccess.Add(request);
            return this.Ok(this.FileDataAccess.Read());
        }

        [HttpPut]
        [SwaggerResponse(200, type: typeof(List<ItemModel>))]
        public IActionResult Put([FromBody] ItemModel request)
        {
            this.FileDataAccess.Update(request);
            return this.Ok(this.FileDataAccess.Read());
        }
    }
}
