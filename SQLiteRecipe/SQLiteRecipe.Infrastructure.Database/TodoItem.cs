using System;
using SQLite;

namespace SQLiteRecipe.Infrastructure.Database
{
    public partial class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}
