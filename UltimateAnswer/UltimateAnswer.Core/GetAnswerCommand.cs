using System;
using System.Threading.Tasks;
using UltimateAnswer.Common;
using UltimateAnswer.Core.Ports;

namespace UltimateAnswer.Core
{
    public class GetAnswerCommand : ICommandHandler<GetAnswerCommandDTO, string>
    {
        private readonly ISuperComputer _superComputer;

        public GetAnswerCommand(ISuperComputer superComputer)
        {
            _superComputer = superComputer;
        }

        public async Task Execute(GetAnswerCommandDTO inDTO,
            Action<string> successHandler, Action<Exception> errorHandler)
        {
            var result = await _superComputer.Answer(inDTO.Question);
            result.Match(successHandler, errorHandler);
        }
    }
}