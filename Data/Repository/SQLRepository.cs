using System.Collections.Generic;
using Todo_List.Models;

namespace Todo_List.Data.Repository
{
    public class SQLRepository : IRepository
    {
        private readonly DB _context;

        public SQLRepository(DB context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new TodoItem to the database with the given name and sets IsDone to false.
        /// </summary>
        /// <param name="todoName">The name of the TodoItem to add.</param>
        public void AddTodo(string todoName)
        {
            TodoItem newItem = new TodoItem()
            {
                Title = todoName,
                IsDone = false
            };
            _context.todoItems.Add(newItem);
            _context.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAllItems() => _context.todoItems;

        /// <summary>
        /// This method updates the state of a TodoItem in the database.
        /// </summary>
        public void ValueChenged(TodoItem changedItem)
        {
            var item = _context.todoItems.Attach(changedItem);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes an item from the database based on the given id.
        /// </summary>
        public void DeleteItem(int id)
        {
            var deletedItem = _context.todoItems.Find(id);

            if (deletedItem != null)
            {
                _context.todoItems.Remove(deletedItem);
                _context.SaveChanges();
            }
        }
    }
}
