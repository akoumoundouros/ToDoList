using ToDoApp.Models.Entities;

namespace ToDoApp.Server.Repositories
{
    public interface IToDoListRepository
    {
        Task<ToDoList> Add(ToDoList entity);
        Task<List<ToDoList>> All();
        Task<ToDoList> Find(Guid id);
        Task Remove(Guid id);
    }
}