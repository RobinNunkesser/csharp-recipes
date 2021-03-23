using Moq;
using NUnit.Framework;
using PlaceholderPosts.Common;

namespace PlaceholderPosts.Core.Tests
{
    public class GetPostCommandTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestExecute()
        {
            var mock = new Mock<IRepository<int, PostEntity>>();
            var mockEntity = new PostEntity();
            mock.Setup(f => f.Retrieve(1))
                .ReturnsAsync(new Result<PostEntity>(mockEntity));
            var service = new GetPostCommand(mock.Object);
            service.Execute(new GetPostServiceDTO() {Id = 1},
                success => Assert.AreEqual(mockEntity, success), Assert.Null);
            mock.Verify(f => f.Retrieve(1), Times.AtMostOnce());
        }
    }
}