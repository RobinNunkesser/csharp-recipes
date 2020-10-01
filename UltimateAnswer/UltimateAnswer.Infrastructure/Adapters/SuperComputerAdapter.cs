using System.Threading.Tasks;
using UltimateAnswer.Common;
using UltimateAnswer.Core.Ports;

namespace UltimateAnswer.Infrastructure.Adapters
{
    public class SuperComputerAdapter : ISuperComputer
    {
        private readonly DeepThought _deepThought;

        public SuperComputerAdapter(DeepThought deepThought) =>
            _deepThought = deepThought;

        public SuperComputerAdapter() => _deepThought = new DeepThought();

        public async Task<Result<string>> Answer(string question) =>
            (await _deepThought.provideAnswer()).ConvertSuccess(answer =>
                answer.ToString());
    }
}