using System;
using CleanArchRecipe.Common;

namespace CleanArchRecipe
{
    public class Interactor : IInputBoundary<object, string>
    {
        public async void Send(object request, IOutputBoundary<string> outputBoundary)
        {
            var gatewayResponse = await new HttpBinGateway().Get();
            gatewayResponse.Match(success =>
            {
                var viewModel = new ResponsePresenter().present(success);
                outputBoundary.Receive(new Response<string>(viewModel));
            }, failure =>
            {
                outputBoundary.Receive(new Response<string>(failure));
            });
        }
    }
}
