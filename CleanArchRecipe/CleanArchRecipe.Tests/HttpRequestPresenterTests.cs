using Xunit;

namespace CleanArchRecipe.Tests
{
    public class HttpRequestPresenterTests
    {
        [Fact]
        public void TestPresent()
        {
            var presenter = new HttpBinResponsePresenter();
            var model = new HttpBinResponseModel
            {
                origin = "origin", url = "url"
            };
            var viewModel = presenter.Present(model);
            Assert.Equal("origin: origin, url: url", viewModel);
        }
    }
}