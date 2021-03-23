using System.Threading.Tasks;
using ExplicitArchitecture;

namespace UltimateAnswer.Core.Ports
{
    public interface ISuperComputer
    {
        Task<Result<string>> Answer(string question);
    }
}