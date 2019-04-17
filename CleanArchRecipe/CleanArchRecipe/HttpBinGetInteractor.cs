using BasicCleanArch;

namespace CleanArchRecipe
{
    public class HttpBinGetInteractor : HttpBinInteractor,
        IUseCase<object, string>
    {
        public HttpBinGetInteractor(HttpBinGateway gateway,
            IPresenter<HttpBinResponseModel, string> presenter) : base(gateway,
            presenter)
        {
        }

        public async void Execute(object request, IDisplayer<string> displayer)
        {
            var gatewayResponse = await _gateway.Get();
            processResult(gatewayResponse, displayer);
        }
    }
}