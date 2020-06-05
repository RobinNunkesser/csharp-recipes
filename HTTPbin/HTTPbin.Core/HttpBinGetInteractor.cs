using HTTPbin.Common;

namespace HTTPbin.Core
{
    public class HttpBinGetInteractor : HttpBinInteractor,
        IUseCase<object, string>
    {
        public HttpBinGetInteractor(IHttpBinGateway gateway,
            IPresenter<HttpBinResponseModel, string> presenter) : base(gateway,
            presenter)
        {
        }

        public async void Execute(object request, IDisplayer<string> displayer,
            int requestCode = 0)
        {
            var gatewayResponse = await _gateway.Get();
            processResult(gatewayResponse, displayer);
        }
    }
}