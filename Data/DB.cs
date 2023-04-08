using Microsoft.EntityFrameworkCore;
using Todo_List.Models;

namespace Todo_List.Data
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) {}

        public DbSet<TodoItem> todoItems { get; set; }
    }
}
