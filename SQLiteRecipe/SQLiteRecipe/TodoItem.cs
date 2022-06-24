using SQLiteRecipe.Core.Ports;

namespace SQLiteRecipe
{
    public class TodoItem : ITodoItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}