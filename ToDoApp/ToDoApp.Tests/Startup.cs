using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.Entities;

namespace ToDoApp.Tests
{
    public class Startup
    {
        private readonly ToDoEntities _db;

        public Startup()
        {
        }
    }
}
