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
                Assert.AreEqual(
                    "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                    success.Title);
                Assert.AreEqual(
                    "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto",
                    success.Body);
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
                Assert.AreEqual(101, success.UserId);
                Assert.AreEqual(1, success.Id);
                Assert.AreEqual("foo", success.Title);
                Assert.AreEqual("bar", success.Body);
            }, failure => throw failure);
        }
    }
}