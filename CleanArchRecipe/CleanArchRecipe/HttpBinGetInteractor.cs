using System;
using BasicCleanArch;

namespace CleanArchRecipe
{
    public class HttpBinGetInteractor : 
        MustInitialize<IPresenter<HttpBinResponseModel, String>>, 
        IUseCase<object, string>
    {
        IPresenter<HttpBinResponseModel, String> _presenter;
        HttpBinGateway _gateway;

        public HttpBinGetInteractor(HttpBinGateway gateway, 
            IPresenter<HttpBinResponseModel, string> presenter) : base(presenter)
        {
            _presenter = presenter;
            _gateway = gateway;
        }

        public async void Execute(object request, 
                                IDisplayer<string> outputBoundary)
        {
            var gatewayResponse = await _gateway.Get();
            gatewayResponse.Match(success =>
            {
                var viewModel = _presenter.present(success);
                outputBoundary.Display(new Result<string>(viewModel));
            }, failure =>
            {
                outputBoundary.Display(new Result<string>(failure));
            });
        }
    }
}
