using System;
using SQLiteRecipe.Core.Ports;

namespace SQLiteRecipe.Infrastructure.Database
{
    public partial class TodoItem : ITodoItem
    {
        
    }

    public static class ITodoItemExtensions
    {
        public static TodoItem ToTodoItem(this ITodoItem entity)
        {
            var item = new TodoItem()
            {
                Name = entity.Name,
                Notes = entity.Notes,
                Done = entity.Done
            };
            if (entity.ID != 0) item.ID = entity.ID;
            return item;
        }
    }
}
