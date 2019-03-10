using System;
using CleanArchRecipe.Common;

namespace CleanArchRecipe
{
    public class GetHttpRequestInteractor : IUseCase<object, string>
    {
        public async void Execute(object request, 
                                IDisplayer<string> outputBoundary)
        {
            var gatewayResponse = await new HttpBinGateway().Get();
            gatewayResponse.Match(success =>
            {
                var viewModel = new HttpRequestPresenter().present(success);
                outputBoundary.Display(new Result<string>(viewModel));
            }, failure =>
            {
                outputBoundary.Display(new Result<string>(failure));
            });
        }
    }
}
