using System;
using Xunit;

namespace CleanArchRecipe.Tests
{
    public class HttpRequestPresenterTests
    {
        [Fact]
        public void TestPresent()
        {
            var presenter = new HttpRequestPresenter();
            var model = new HttpRequestModel
            {
                origin = "origin",
                url = "url"
            };
            var viewModel = presenter.present(model);
            Assert.Equal("origin: origin, url: url", viewModel);
        }
    }
}