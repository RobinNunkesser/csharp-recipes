using System;
using HTTPbin.Common;

namespace HTTPbin.Core
{
    public class HttpBinGetInteractor : HttpBinInteractor,
        IQuery<object, string>
    {
        public HttpBinGetInteractor(IHttpBinGateway gateway,
            IPresenter<HttpBinResponseModel, string> presenter) : base(gateway,
            presenter)
        {
        }

        public async void Execute(object request, Action<string> successHandler,
            Action<Exception> errorHandler)
        {
            var gatewayResponse = await _gateway.Get();
            gatewayResponse.Match(success =>
            {
                var viewModel = _presenter.Present(success);
                successHandler(viewModel);
            }, errorHandler);
        }
    }
}