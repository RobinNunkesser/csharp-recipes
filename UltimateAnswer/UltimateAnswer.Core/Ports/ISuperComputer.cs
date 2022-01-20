using System.Threading.Tasks;
using Italbytz.Ports.Common;

namespace UltimateAnswer.Core.Ports
{
    public interface ISuperComputer
    {
        Task<string> Answer(string question);
    }
}