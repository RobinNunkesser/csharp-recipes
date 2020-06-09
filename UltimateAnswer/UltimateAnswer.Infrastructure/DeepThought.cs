using System.Threading.Tasks;
using UltimateAnswer.Common;

namespace UltimateAnswer.Infrastructure
{
    public class DeepThought
    {
        public async Task<Result<int>> provideAnswer()
        {
            await Task.Delay(1000);
            return new Result<int>(42);
        }
    }
}