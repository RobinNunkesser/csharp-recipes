using HTTPbin.Common;

namespace HTTPbin.Core
{
    public abstract class
        HttpBinInteractor : MustInitialize<
            IPresenter<HttpBinResponseModel, string>>
    {
        protected readonly IHttpBinGateway _gateway;
        protected readonly IPresenter<HttpBinResponseModel, string> _presenter;

        protected HttpBinInteractor(IHttpBinGateway gateway,
            IPresenter<HttpBinResponseModel, string> presenter) : base(
            presenter)
        {
            _presenter = presenter;
            _gateway = gateway;
        }

        protected void processResult(Result<HttpBinResponseModel> result,
            IDisplayer<string> displayer)
        {
            result.Match(success =>
            {
                var viewModel = _presenter.Present(success);
                displayer.Display(viewModel);
            }, failure => displayer.Display(failure));
        }
    }
}