using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonPorts;
using SQLite;
using SQLiteRecipe.Core.Ports;

namespace SQLiteRecipe.Infrastructure.Database.Adapters
{
    public class RepositoryAdapter : IRepository<int, ITodoItem>
    {
        readonly SQLiteAsyncConnection _database;

        public RepositoryAdapter(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TodoItem>().Wait();
        }        

        public async Task<Result<int>> Create(ITodoItem entity)
        {
            // TODO: Seems to return the number of created items and not the ID
            var inserted = await _database.InsertAsync(entity.ToTodoItem());
            return new Result<int>(inserted);
        }

        public async Task<Result<bool>> Delete(int id)
        {            
            var deleted = await _database.DeleteAsync<int>(id);
            return new Result<bool>(deleted == 1);
        }

        public async Task<Result<ITodoItem>> Retrieve(int id)
        {
            var item = await _database.Table<TodoItem>()
                           .Where(i => i.ID == id).FirstOrDefaultAsync();
            return new Result<ITodoItem>(item);
        }

        public async Task<Result<bool>> Update(int id, ITodoItem entity)
        {
            var updatedRows = await _database.UpdateAsync(entity.ToTodoItem());
            return new Result<bool>(updatedRows == 1);
        }

        async Task<Result<List<ITodoItem>>> IRepository<int, ITodoItem>.RetrieveAll()
        {
            var results = await _database.Table<TodoItem>().ToListAsync();
            return new Result<List<ITodoItem>>(results.Select(result => (ITodoItem)result).ToList());

        }

        async Task<Result<List<ITodoItem>>> GetItemsNotDoneAsync()
        {
            var results = await _database.QueryAsync<TodoItem>
                           ("SELECT * FROM [TodoItem] WHERE [Done] = 0");
            return new Result<List<ITodoItem>>(results.Select(result => (ITodoItem)result).ToList());
        }

        async Task<Result<bool>> SaveItemAsync(TodoItem item)
        {
            if (item.ID != 0)
            {
                return await Update(0,item);
            }
            else
            {
                return (await Create(item)).Map(success => true);
            }
        }
    }
}
