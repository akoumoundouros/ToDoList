using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models.Dtos
{
    public class ToDoListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ToDoListItemDto>? Items { get; set; }
    }
}
