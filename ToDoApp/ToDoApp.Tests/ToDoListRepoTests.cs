using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Models.Entities;
using ToDoApp.Server.Repositories;

namespace ToDoApp.Tests
{
    public class ToDoListRepoTests
    {
        private IToDoListRepository _listRepo;
        
        public ToDoListRepoTests()
        {
            var services = new ServiceCollection()
                .AddDbContext<ToDoEntities>(options =>
                {
                    options.UseInMemoryDatabase("ToDoDb");
                })
                .AddEntityFrameworkInMemoryDatabase()
                .AddScoped<IToDoListRepository, ToDoListRepository>()
                .BuildServiceProvider();

            _listRepo = services.GetRequiredService<IToDoListRepository>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Should_add_new_list_when_valid()
        {
            var id = Guid.NewGuid();
            var toDoList = new ToDoList()
            {
                Id = id,
                Name = "Test",
            };

            await _listRepo.Add(toDoList);

            var listFromDb = await _listRepo.Find(id);

            Assert.AreEqual(toDoList, listFromDb);
        }

        [Test]
        public async Task Should_delete_to_do_list()
        {
            // Arrange
            var id = Guid.NewGuid();
            var toDoList = new ToDoList()
            {
                Id = id,
                Name = "Test",
            };
            await _listRepo.Add(toDoList);

            // Act
            await _listRepo.Remove(id);

            // Assert
            var lists = await _listRepo.All();
            Assert.Zero(lists.Count);
        }
    }
}