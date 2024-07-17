using System.Collections.ObjectModel;

namespace SwaggerApi.Models
{
    public class TodoList
    {
        private readonly List<TodoItem> _items;

        public ReadOnlyCollection<TodoItem> Items => _items.AsReadOnly();

        public TodoList()
        {
            _items =
            [
                new TodoItem { Id = 1, IsComplete = false, Name = "Go to Supermarket" },
                new TodoItem { Id = 2, IsComplete = false, Name = "Buy a new phone" },
                new TodoItem { Id = 3, IsComplete = false, Name = "Go to the gym" },
                new TodoItem { Id = 4, IsComplete = false, Name = "Read a book" },
                new TodoItem { Id = 5, IsComplete = false, Name = "Go to the cinema" },
                new TodoItem { Id = 6, IsComplete = true, Name = "Prepare breakfast" },
                new TodoItem { Id = 7, IsComplete = true, Name = "Prepare lunch" },
                new TodoItem { Id = 8, IsComplete = true, Name = "Prepare dinner" },
                new TodoItem { Id = 9, IsComplete = true, Name = "Go to the park" },
                new TodoItem { Id = 10, IsComplete = true, Name = "Go to the beach" }
            ];
        }

        public void Add(TodoItem item)
        {
            _items.Add(item);
        }

        public void Remove(TodoItem item)
        {
            _items.Add(item);
        }
    }
}
