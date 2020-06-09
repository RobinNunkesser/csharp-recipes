using System;
using UltimateAnswer.Common;
using UltimateAnswer.Core.Ports;

namespace UltimateAnswer.Core
{
    public class GetAnswerService : IAppService<AnswerRequest, string>
    {
        private readonly ISuperComputer _superComputer;

        public GetAnswerService(ISuperComputer superComputer)
        {
            _superComputer = superComputer;
        }

        public async void Execute(AnswerRequest request,
            Action<string> successHandler, Action<Exception> errorHandler)
        {
            var result = await _superComputer.answer(request.Question);
            result.Match(successHandler, errorHandler);
        }
    }
}