using System.Threading.Tasks;
using NUnit.Framework;

namespace HTTPbin.Infrastructure.Tests
{
    public class HttpBinAdapterTests
    {
        [Test]
        public async Task TestGet()
        {
            var httpBinAdapter = new HttpBinAdapter();
            var response = await httpBinAdapter.Get();

            response.Match(success =>
            {
                Assert.NotNull(success.Origin);
                Assert.NotNull(success.Url);
            }, failure => throw failure);
        }
    }
}