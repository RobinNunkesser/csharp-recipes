using HTTPbin.Common;
using Newtonsoft.Json;

namespace HTTPbin.Core
{
    public class HttpBinPostInteractor : HttpBinInteractor,
        IUseCase<HttpBinPostRequest, string>
    {
        public HttpBinPostInteractor(IHttpBinGateway gateway,
            IPresenter<HttpBinResponseModel, string> presenter) : base(gateway,
            presenter)
        {
        }

        public async void Execute(HttpBinPostRequest request,
            IDisplayer<string> displayer, int requestCode = 0)
        {
            var json = JsonConvert.SerializeObject(request);
            var gatewayResponse = await _gateway.Post(json);
            processResult(gatewayResponse, displayer);
        }
    }
}