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
        public async Task TestReadAllPosts()
        {
            var api = new JSONPlaceholderAPI();
            var result = await api.ReadAllPosts();

            Assert.AreEqual(100, result.Count);
        }

        [Test]
        public async Task TestReadPost()
        {
            var api = new JSONPlaceholderAPI();
            var result = await api.ReadPost(1);

            Assert.AreEqual(1, result.UserId);
            Assert.AreEqual(1, result.Id);
            Assert.True(result.Title.StartsWith("sunt aut facere repella"));
            Assert.True(result.Body.StartsWith("quia et suscipit\nsuscip"));
        }

        [Test]
        public async Task TestCreatePost()
        {
            var api = new JSONPlaceholderAPI();
            var result = await api.CreatePost(new Post()
            {
                Title = "foo",
                Body = "bar",
                UserId = 1
            });

            Assert.AreEqual(1, result.UserId);
            Assert.AreEqual(101, result.Id);
            Assert.AreEqual("foo", result.Title);
            Assert.AreEqual("bar", result.Body);
        }
    }
}