using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models.Entities
{
    public class ToDoList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ToDoListItem> ToDoListItems { get; set; }
    }
}
