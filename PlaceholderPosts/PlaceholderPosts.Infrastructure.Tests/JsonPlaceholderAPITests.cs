using System.Threading.Tasks;
using HTTPbin.Infrastructure;
using NUnit.Framework;

namespace PlaceholderPosts.Infrastructure.Tests
{
    public class JsonPlaceholderAPITests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestReadAll()
        {
            var api = new JSONPlaceholderAPI();
            var response = await api.ReadAll();

            response.Match(success => { Assert.AreEqual(100, success.Count); },
                failure => throw failure);
        }
    }
}