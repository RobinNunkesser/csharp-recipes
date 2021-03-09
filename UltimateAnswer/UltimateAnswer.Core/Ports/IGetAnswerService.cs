using System;
using UltimateAnswer.Common;

namespace UltimateAnswer.Core.Ports
{
    public interface IGetAnswerService : ICommandHandler<string, string> {
    }
}
