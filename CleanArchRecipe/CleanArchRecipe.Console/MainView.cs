using System;
using BasicCleanArch;

namespace CleanArchRecipe.Console
{
    public class MainView : IDisplayer<string>
    {
        private readonly IUseCase<HttpBinPostRequest, string> _interactor =
            new HttpBinPostInteractor(new HttpBinGateway(),
                new HttpBinResponsePresenter());

        public void Display(string value, int requestCode = 0)
        {
            System.Console.WriteLine(value);
        }

        public void Display(Exception error)
        {
            System.Console.WriteLine(error);
        }

        public void Start()
        {
            System.Console.WriteLine("Term to post? ");
            var term = System.Console.ReadLine();
            _interactor.Execute(new HttpBinPostRequest {term = term}, this);
            System.Console.WriteLine("\nAsync operation. Press key to abort");
            var key = System.Console.ReadKey();
        }
    }
}