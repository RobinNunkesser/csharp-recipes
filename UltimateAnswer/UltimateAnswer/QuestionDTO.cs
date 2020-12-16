using System;
using UltimateAnswer.Core.Ports;

namespace UltimateAnswer
{
    public class QuestionDTO : IQuestion
    {
        public QuestionDTO()
        {
        }

        public string Question { get; set; }
    }
}
