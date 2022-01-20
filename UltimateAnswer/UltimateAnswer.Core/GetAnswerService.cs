using System;
using System.Threading.Tasks;
using UltimateAnswer.Core.Ports;

namespace UltimateAnswer.Core
{
    public class GetAnswerService : IGetAnswerService
    {
        private readonly ISuperComputer _superComputer;

        public GetAnswerService(ISuperComputer superComputer)
        {
            _superComputer = superComputer;
        }

        public async Task Execute(String inDTO, Action<String> successHandler,
            Action<Exception> errorHandler)
        {
            try
            {
                successHandler(await _superComputer.Answer(inDTO));
            }
            catch (Exception ex)
            {
                errorHandler(ex);
            }
        }
    }
}