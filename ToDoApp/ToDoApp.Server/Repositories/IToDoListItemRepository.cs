using ToDoApp.Models.Entities;

namespace ToDoApp.Server.Repositories
{
    public interface IToDoListItemRepository
    {
        Task<ToDoListItem> Add(ToDoListItem entity);
        Task<List<ToDoListItem>> All(Guid listId);
        Task Remove(Guid id);
    }
}