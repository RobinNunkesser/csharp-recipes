using System.Threading.Tasks;

namespace UltimateAnswer.Infrastructure
{
    public class DeepThought
    {
        public async Task<int> ProvideAnswer()
        {
            await Task.Delay(1000);
            return 42;
        }
    }
}