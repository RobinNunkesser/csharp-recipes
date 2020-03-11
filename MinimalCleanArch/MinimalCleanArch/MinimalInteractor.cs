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

        public void Execute(object request, IDisplayer<string> displayer,
            int requestCode = 0)
        {
            var viewModel = _presenter.Present(42);
            displayer.Display(viewModel, requestCode);
        }
    }
}
