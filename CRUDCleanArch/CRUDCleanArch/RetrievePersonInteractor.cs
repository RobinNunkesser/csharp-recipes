using BasicCleanArch;

namespace CRUDCleanArch
{
    public class
        RetrievePersonInteractor : IUseCase<RetrievePersonRequest,
            UpdatePageViewModel>
    {
        public void Execute(RetrievePersonRequest request,
            IDisplayer<UpdatePageViewModel> outputBoundary)
        {
            var person = PersonStorageSingleton.Instance.Retrieve(request.Key);
            var presenter = new PersonPresenter(request.Key);
            var viewModel = presenter.present(person);
            outputBoundary.Display(new Result<UpdatePageViewModel>(viewModel));
        }
    }
}