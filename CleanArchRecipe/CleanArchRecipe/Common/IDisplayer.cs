namespace CleanArchRecipe.Common
{
    public interface IDisplayer<T>
    {
        void Display(Result<T> response);         
    }
}