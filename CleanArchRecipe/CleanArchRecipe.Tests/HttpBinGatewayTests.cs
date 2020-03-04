using Xunit;

namespace CleanArchRecipe.Tests
{
    public class HttpBinGatewayTests
    {
        [Fact]
        public async void TestGet()
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