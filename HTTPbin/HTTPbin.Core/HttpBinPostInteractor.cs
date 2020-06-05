using System;
using HTTPbin.Common;
using Newtonsoft.Json;

namespace HTTPbin.Core
{
    public class HttpBinPostInteractor : HttpBinInteractor,
        IQuery<HttpBinPostRequest, string>
    {
        public HttpBinPostInteractor(IHttpBinGateway gateway,
            IPresenter<HttpBinResponseModel, string> presenter) : base(gateway,
            presenter)
        {
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