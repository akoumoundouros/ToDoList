using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.Entities;
using ToDoApp.Server.Repositories;

namespace ToDoApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController(IToDoListRepository toDoListRepo, IToDoListItemRepository toDoItemRepo) : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepo = toDoListRepo;
        private readonly IToDoListItemRepository _toDoItemRepo = toDoItemRepo;

        [HttpGet]
        public async Task<ApiResponse<ToDoListItemDto>> Get(Guid listId)
        {
            var query = await _toDoItemRepo.All(listId);
            var data = query.Select(s => new ToDoListItemDto()
            {
                Id = s.Id.ToString(),
                ListId = s.ToDoListId.ToString(),
                Title = s.Title,
                Position = s.Position,
            }).ToList();
            return new ApiResponse<ToDoListItemDto>() { Data = data };
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Delete([FromRoute]string id)
        {
            await _toDoItemRepo.Remove(Guid.Parse(id));
        }

        [HttpPost]
        public async Task<ToDoListItemDto> Create(ToDoListItemDto model)
        {
            var toDoList = new ToDoListItem()
            {
                ToDoListId = Guid.Parse(model.ListId),
                Title = model.Title,
                Position = model.Position,
            };
            var newItem = await _toDoItemRepo.Add(toDoList);
            model.Id = newItem.Id.ToString();
            return model;
        }

        
    }
}
