using System;
using CleanArchRecipe.Common;

namespace CleanArchRecipe
{
    public class GetHttpRequestInteractor : MustInitialize<IPresenter<HttpRequestModel, String>>, IUseCase<object, string>
    {
        IPresenter<HttpRequestModel, String> _presenter;

        public GetHttpRequestInteractor(IPresenter<HttpRequestModel, string> presenter) : base(presenter)
        {
            _presenter = presenter;
        }

        public async void Execute(object request, 
                                IDisplayer<string> outputBoundary)
        {
            var gatewayResponse = await new HttpBinGateway().Get();
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
