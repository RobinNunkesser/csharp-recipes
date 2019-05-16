using BasicCleanArch;

namespace CleanArchRecipe.Console
{
    public class MainView : IDisplayer<string>
    {
        private readonly IUseCase<HttpBinPostRequest, string> _interactor =
            new HttpBinPostInteractor(new HttpBinGateway(),
                new HttpBinResponsePresenter());

        public void Display(Result<string> response)
        {
            response.Match(success => { System.Console.WriteLine(success); },
                failure => { System.Console.WriteLine(failure); });
        }

        public void Start()
        {
            System.Console.WriteLine("Term to post? ");
            var term = System.Console.ReadLine();
            _interactor.Execute(new HttpBinPostRequest {term = term}, this);
            System.Console.WriteLine("\nAsync operation running. Press key to abort");
            var key = System.Console.ReadKey();
        }
    }
}