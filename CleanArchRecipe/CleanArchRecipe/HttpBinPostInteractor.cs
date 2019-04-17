using System;
using BasicCleanArch;
using Newtonsoft.Json;

namespace CleanArchRecipe
{
    public class HttpBinPostInteractor :
        MustInitialize<IPresenter<HttpBinResponseModel, String>>,
        IUseCase<HttpBinPostRequest, string>
    {
        IPresenter<HttpBinResponseModel, String> _presenter;
        HttpBinGateway _gateway;

        public HttpBinPostInteractor(HttpBinGateway gateway,
            IPresenter<HttpBinResponseModel, string> presenter) : base(presenter)
        {
            _presenter = presenter;
            _gateway = gateway;
        }

        public async void Execute(HttpBinPostRequest request,
                                IDisplayer<string> outputBoundary)
        {
            var json = JsonConvert.SerializeObject(request);
            var gatewayResponse = await _gateway.Post(json);
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