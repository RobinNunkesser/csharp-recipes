using System;
using HTTPbin.Common;

namespace HTTPbin.Core
{
    public class HttpBinGetInteractor : MustInitialize<
        IPresenter<HttpBinResponseModel, string>>, IQuery<object, string>
    {
        private readonly IHttpBinGateway _gateway;
        private readonly IPresenter<HttpBinResponseModel, string> _presenter;

        public HttpBinGetInteractor(IHttpBinGateway gateway,
            IPresenter<HttpBinResponseModel, string> presenter) : base(
            presenter)
        {
            _presenter = presenter;
            _gateway = gateway;
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