using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using SQLiteRecipe.Infrastructure.Database.Adapters;

namespace SQLiteRecipe.Infrastructure.Database.Tests
{
    public class Tests
    {
        RepositoryAdapter repository;

        [SetUp]
        public void Setup()
        {
            repository = new RepositoryAdapter(Path.GetTempFileName());            
        }

        [Test]
        public async Task Test1()
        {
            var item = new TodoItem()
            {
                Name = "Name",
                Notes = "Notes",
                Done = false
            };
            var result = await repository.Create(item);
            result.Match(
                success => { Assert.AreEqual(1, success); },
                failure => { Assert.Fail(failure.ToString()); });
            result = await repository.Create(item);
            result.Match(
                success => { Assert.AreEqual(2, success); },
                failure => { Assert.Fail(failure.ToString()); });
            Assert.Pass();
        }
    }
}