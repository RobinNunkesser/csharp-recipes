using System.Threading.Tasks;
using ExplicitArchitecture;

namespace UltimateAnswer.Infrastructure
{
    public class DeepThought
    {
        public async Task<Result<int>> ProvideAnswer()
        {
            await Task.Delay(1000);
            return new Result<int>(42);
        }
    }
}