namespace CleanArchRecipe.Common
{
    public interface IInputBoundary<T>
    {
        void Send(IOutputBoundary<T> outputBoundary, Request request = null);
    }

}