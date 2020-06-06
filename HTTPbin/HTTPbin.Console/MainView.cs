using HTTPbin.Common;
using HTTPbin.Core;
using HTTPbin.Infrastructure;

namespace HTTPbin.Console
{
    public class MainView
    {
        private readonly IAppService<HttpBinPostRequest, string> _interactor =
            new HttpBinPostInteractor(new HttpBinGateway(),
                new HttpBinResponsePresenter());

        public void Start()
        {
            System.Console.WriteLine("Term to post? ");
            var term = System.Console.ReadLine();
            _interactor.Execute(new HttpBinPostRequest {term = term},
                System.Console.Write, System.Console.Write);
            System.Console.WriteLine("\nAsync operation. Press key to abort");
            System.Console.ReadKey();
        }
    }
}