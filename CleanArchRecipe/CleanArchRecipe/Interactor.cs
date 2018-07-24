using System;
using CleanArchRecipe.Common;

namespace CleanArchRecipe
{
    public class Interactor : IInputBoundary<ResponseEntity>
    {
        public async void Send(IOutputBoundary<ResponseEntity> outputBoundary,
                               Request request = null)
        {
            var gatewayResponse = await new HttpBinGateway().Get();
            outputBoundary.Receive(gatewayResponse);
        }
    }
}
