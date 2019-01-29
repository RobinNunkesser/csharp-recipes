namespace CleanArchRecipe.Common
{
    public interface IInputBoundary<Request, Response>
    {
        void Send(Request request, IOutputBoundary<Response> outputBoundary);
    }
}