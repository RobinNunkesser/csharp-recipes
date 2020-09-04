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
            var response = await api.ReadAllPosts();

            response.Match(success => { Assert.AreEqual(100, success.Count); },
                failure => throw failure);
        }

        [Test]
        public async Task TestReadPost()
        {
            var api = new JSONPlaceholderAPI();
            var response = await api.ReadPost(1);

            response.Match(success =>
            {
                Assert.AreEqual(1, success.UserId);
                Assert.AreEqual(1, success.Id);
                Assert.True(success.Title.StartsWith("sunt aut facere repella"));
                Assert.True(success.Body.StartsWith("quia et suscipit\nsuscip"));
            }, failure => throw failure);
        }

        [Test]
        public async Task TestCreatePost()
        {
            var api = new JSONPlaceholderAPI();
            var response = await api.CreatePost(new Post()
            {
                Title = "foo", Body = "bar", UserId = 1
            });

            response.Match(success =>
            {
                Assert.AreEqual(1, success.UserId);
                Assert.AreEqual(101, success.Id);
                Assert.AreEqual("foo", success.Title);
                Assert.AreEqual("bar", success.Body);
            }, failure => throw failure);
        }
    }
}