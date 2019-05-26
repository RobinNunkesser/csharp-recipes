using BasicCleanArch;

namespace ComplexNavigation
{
    public class NavigationInteractor : IUseCase<NavigationRequest, ViewModel>
    {
        public void Execute(NavigationRequest request,
            IDisplayer<ViewModel> outputBoundary)
        {
            switch (request.value)
            {
                case 1:
                    outputBoundary.Display(
                        new Result<ViewModel>(new DestinationOneViewModel()));
                    break;
                case 2:
                    outputBoundary.Display(
                        new Result<ViewModel>(new DestinationTwoViewModel()));
                    break;
                case 3:
                    outputBoundary.Display(
                        new Result<ViewModel>(new DestinationThreeViewModel()));
                    break;
            }
        }
    }
}