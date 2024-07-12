using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models.Dtos
{
    public class ToDoListItemDto
    {
        public string Id { get; set; }
        public string ListId { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }
    }
}
