using Microsoft.EntityFrameworkCore;
using ToDoApp.Models.Entities;

namespace ToDoApp.Server.Repositories
{
    public class ToDoListItemRepository : IToDoListItemRepository
    {
        private ToDoEntities _db;

        public ToDoListItemRepository(ToDoEntities dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<ToDoListItem>> All(Guid listId)
        {
            var listItems = await _db.ToDoListItems
                .Where(i => i.ToDoListId == listId)
                .OrderBy(i => i.Position)
                .ToListAsync();
            return listItems;
        }


        public async Task<ToDoListItem> Add(ToDoListItem entity)
        {
            await _db.ToDoListItems.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task Remove(Guid id)
        {
            var entity = await _db.ToDoListItems.FindAsync(id);
            _db.ToDoListItems.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
