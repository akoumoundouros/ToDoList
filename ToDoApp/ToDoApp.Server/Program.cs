
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models.Entities;
using ToDoApp.Server.Repositories;

namespace ToDoApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ToDoEntities>(options =>
            {
                options.UseInMemoryDatabase("ToDoDb");
            });


            builder.Services.AddScoped<IToDoListRepository, ToDoListRepository>();
            builder.Services.AddScoped<IToDoListItemRepository, ToDoListItemRepository>();

            var app = builder.Build();

            using(var scope = app.Services.CreateScope())
            {
                SetupDatabaseRecords(scope.ServiceProvider.GetService<ToDoEntities>()).Wait();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }

        private static async Task SetupDatabaseRecords(ToDoEntities db)
        {
            await db.ToDoLists.AddAsync(new ToDoList()
            {
                Id = Guid.NewGuid(),
                Name = "Test List 1",
                ToDoListItems = new []
                {
                    new ToDoListItem
                    { 
                        Id = Guid.NewGuid(),
                        Title = "Go to work",
                        Position = 1,
                    },
                    new ToDoListItem
                    {
                        Id = Guid.NewGuid(),
                        Title = "Go home",
                        Position = 2,
                    },
                    new ToDoListItem
                    {
                        Id = Guid.NewGuid(),
                        Title = "Watch Game of Thrones",
                        Position = 3,
                    }
                }
            });
            await db.SaveChangesAsync();
        }
    }
}
