using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models.Entities
{
    public class ToDoListItem
    {
        public Guid Id { get; set; }
        public Guid ToDoListId { get; set; }
        public string Title { get; set; }

        public int Position { get; set; }

        public virtual ToDoList ToDoList { get; set; }
        
    }
}
