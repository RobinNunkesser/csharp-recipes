using BasicCleanArch;

namespace CleanArchRecipe
{
    public abstract class
        HttpBinInteractor : MustInitialize<
            IPresenter<HttpBinResponseModel, string>>
    {
        protected readonly HttpBinGateway _gateway;
        private readonly IPresenter<HttpBinResponseModel, string> _presenter;

        protected HttpBinInteractor(HttpBinGateway gateway,
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