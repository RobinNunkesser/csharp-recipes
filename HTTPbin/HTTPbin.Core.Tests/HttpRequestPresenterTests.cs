using NUnit.Framework;

namespace HTTPbin.Core.Tests
{
    public class HttpRequestPresenterTests
    {
        [Test]
        public void TestPresent()
        {
            var presenter = new HttpBinResponsePresenter();
            var model = new HttpBinResponseModel
            {
                Origin = "origin", Url = new System.Uri("http://site.tld/")
            };
            var viewModel = presenter.Present(model);
            Assert.AreEqual("origin: origin, url: http://site.tld/", viewModel);
        }
    }
}