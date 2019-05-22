using BasicCleanArch;
namespace MinimalCleanArch
{
    public class MinimalInteractor : MustInitialize<IPresenter<int, string>>, 
        IUseCase<object,string>
    {
        IPresenter<int, string> _presenter;

        public MinimalInteractor(IPresenter<int, string> presenter) 
        : base(presenter)
        {
            _presenter = presenter;
        }

        public void Execute(object request, IDisplayer<string> displayer)
        {
            var viewModel = _presenter.present(42);
            displayer.Display(new Result<string>(viewModel));
        }
    }
}
