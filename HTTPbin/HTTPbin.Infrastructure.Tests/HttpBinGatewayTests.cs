using System.Threading.Tasks;
using NUnit.Framework;

namespace HTTPbin.Infrastructure.Tests
{
    public class HttpBinGatewayTests
    {
        [Test]
        public async Task TestGet()
        {
            var gateway = new HttpBinGateway();
            var gatewayResponse = await gateway.Get();

            gatewayResponse.Match(success =>
            {
                Assert.NotNull(success.Origin);
                Assert.NotNull(success.Url);
            }, failure => throw failure);
        }
    }
}