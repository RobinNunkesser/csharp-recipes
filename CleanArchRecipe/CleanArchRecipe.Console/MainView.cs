using System;
using BasicCleanArch;
using static System.Console;

namespace CleanArchRecipe.Console
{
    public class MainView : IDisplayer<string>
    {
        private readonly IUseCase<HttpBinPostRequest, string> _interactor =
            new HttpBinPostInteractor(new HttpBinGateway(),
                new HttpBinResponsePresenter());

        public void Display(string value, int requestCode = 0) => Write(value);        
        public void Display(Exception error) => Write(error);
        
        public void Start()
        {
            WriteLine("Term to post? ");
            var term = ReadLine();
            _interactor.Execute(new HttpBinPostRequest {term = term}, this);
            WriteLine("\nAsync operation. Press key to abort");
            ReadKey();
        }
    }
}