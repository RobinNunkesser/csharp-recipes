using UltimateAnswer.Common;
using UltimateAnswer.Core;
using UltimateAnswer.Infrastructure.Adapters;

namespace UltimateAnswer.Console
{
    public class MainView
    {
        private readonly IAppService<AnswerRequest, string> _service =
            new GetAnswerService(new SuperComputerAdapter());

        public void Start()
        {
            System.Console.WriteLine("Question? ");
            var question = System.Console.ReadLine();
            _service.Execute(new AnswerRequest() {Question = question},
                System.Console.Write, System.Console.Write);
            System.Console.WriteLine("\nAsync operation. Press key to abort");
            System.Console.ReadKey();
        }
    }
}