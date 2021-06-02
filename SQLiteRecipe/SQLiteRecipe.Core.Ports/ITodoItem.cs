using System;

namespace SQLiteRecipe.Core.Ports
{
    public interface ITodoItem
    {
        int ID { get; set; }
        string Name { get; set; }
        string Notes { get; set; }
        bool Done { get; set; }
    }
}
