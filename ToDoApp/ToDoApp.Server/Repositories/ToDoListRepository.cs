using Microsoft.EntityFrameworkCore;
using ToDoApp.Models.Entities;

namespace ToDoApp.Server.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private ToDoEntities _db;

        public ToDoListRepository(ToDoEntities dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<ToDoList>> All() => await _db.ToDoLists.ToListAsync();

        public async Task<ToDoList> Find(Guid id) => await _db.ToDoLists.FindAsync(id);

        public async Task<ToDoList> Add(ToDoList entity)
        {
            await _db.ToDoLists.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task Remove(Guid id)
        {
            var item = await _db.ToDoLists.FindAsync(id);
            if(item != null)
            {
                _db.ToDoLists.Remove(item);
                await _db.SaveChangesAsync();
            }
        }
    }
}
