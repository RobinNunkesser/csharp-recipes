using Italbytz.Ports.Common;
using System.Threading.Tasks;
using UltimateAnswer.Core;
using UltimateAnswer.Infrastructure.Adapters;

namespace UltimateAnswer.Console
{
    public class MainView
    {
        private readonly IService<string, string> _service =
            new GetAnswerService(new SuperComputerAdapter());

        public async Task StartAsync()
        {
            System.Console.WriteLine("Question? ");
            var question = System.Console.ReadLine();
            try
            {
                System.Console.Write(await _service.Execute(question));        
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine(ex.Message);
            }  
            System.Console.ReadKey();
        }
    }
}