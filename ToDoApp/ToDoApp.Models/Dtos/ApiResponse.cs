using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models.Dtos
{
    public class ApiResponse<T> where T : class
    {
        public List<T> Data { get; set; }

        public int ResultCount
        {
            get { return Data.Count; }
        }
    }
}
