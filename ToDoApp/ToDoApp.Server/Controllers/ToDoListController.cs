using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.Entities;
using ToDoApp.Server.Repositories;

namespace ToDoApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController(IToDoListRepository toDoListRepo, IToDoListItemRepository toDoItemRepo) : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepo = toDoListRepo;
        private readonly IToDoListItemRepository _toDoItemRepo = toDoItemRepo;

        [HttpGet]
        public async Task<List<ToDoListDto>> Get()
        {
            var query = await _toDoListRepo.All();
            var data = query.Select(s => new ToDoListDto()
            {
                Id = s.Id.ToString(),
                Name = s.Name,
            }).ToList();
            foreach (var item in data)
            {
                item.Items = (await _toDoItemRepo.All(Guid.Parse(item.Id)))
                    .Select(s => new ToDoListItemDto
                    {
                        Id = s.Id.ToString(),
                        ListId = s.ToDoListId.ToString(),
                        Title = s.Title,
                        Position = s.Position
                    }).ToList();
            }
            return data;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Delete([FromRoute]string id)
        {
            await _toDoListRepo.Remove(Guid.Parse(id));
        }

        [HttpPost]
        public async Task<ToDoListDto> Create(ToDoListDto model)
        {
            var toDoList = new ToDoList()
            {
                Name = model.Name
            };
            var newList = await _toDoListRepo.Add(toDoList);
            model.Id = newList.Id.ToString();
            
            return model;
        }

        
    }
}
