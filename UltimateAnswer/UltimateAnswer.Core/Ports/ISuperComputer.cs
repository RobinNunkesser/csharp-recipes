using System.Threading.Tasks;
using UltimateAnswer.Common;

namespace UltimateAnswer.Core.Ports
{
    public interface ISuperComputer
    {
        Task<Result<string>> Answer(string question);
    }
}