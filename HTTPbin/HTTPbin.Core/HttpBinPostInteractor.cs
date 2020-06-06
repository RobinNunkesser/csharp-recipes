using System;
using HTTPbin.Common;
using Newtonsoft.Json;

namespace HTTPbin.Core
{
    public class HttpBinPostInteractor :
        MustInitialize<IPresenter<HttpBinResponseModel, string>>,
        IAppService<HttpBinPostRequest, string>
    {
        private readonly IHttpBinGateway _gateway;
        private readonly IPresenter<HttpBinResponseModel, string> _presenter;

        public HttpBinPostInteractor(IHttpBinGateway gateway,
            IPresenter<HttpBinResponseModel, string> presenter) : base(
            presenter)
        {
            _presenter = presenter;
            _gateway = gateway;
        }

        public async void Execute(HttpBinPostRequest request,
            Action<string> successHandler, Action<Exception> errorHandler)
        {
            var json = JsonConvert.SerializeObject(request);
            var gatewayResponse = await _gateway.Post(json);
            gatewayResponse.Match(success =>
            {
                var viewModel = _presenter.Present(success);
                successHandler(viewModel);
            }, errorHandler);
        }
    }
}