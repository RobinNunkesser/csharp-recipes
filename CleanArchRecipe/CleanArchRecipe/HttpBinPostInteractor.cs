using BasicCleanArch;
using Newtonsoft.Json;

namespace CleanArchRecipe
{
    public class HttpBinPostInteractor : HttpBinInteractor,
        IUseCase<HttpBinPostRequest, string>
    {
        public HttpBinPostInteractor(HttpBinGateway gateway,
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