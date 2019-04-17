using BasicCleanArch;

namespace CleanArchRecipe
{
    public abstract class
        HttpBinInteractor : MustInitialize<
            IPresenter<HttpBinResponseModel, string>>
    {
        protected HttpBinGateway _gateway;
        protected IPresenter<HttpBinResponseModel, string> _presenter;

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
                var viewModel = _presenter.present(success);
                displayer.Display(new Result<string>(viewModel));
            }, failure => { displayer.Display(new Result<string>(failure)); });
        }
    }
}