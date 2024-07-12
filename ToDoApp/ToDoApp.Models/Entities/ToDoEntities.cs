using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models.Entities
{
    public class ToDoEntities : DbContext
    {
        public ToDoEntities(DbContextOptions<ToDoEntities> options) : base(options) { }

        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoListItem> ToDoListItems { get; set; }


    }
}
