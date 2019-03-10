using System;
namespace CleanArchRecipe.Common
{
    public class Result<T>
    {
        int tag;
        T value;
        Exception error;

        public Result(T value) { this.value = value; tag = 1; }
        public Result(Exception error) { this.error = error; tag = 2; }

        public virtual void Match(
            Action<T> successHandler,
            Action<Exception> errorHandler
            )
        {
            if (successHandler == null) 
                throw new ArgumentNullException("successHandler");
            if (errorHandler == null) 
                throw new ArgumentNullException("errorHandler");

            switch (tag)
            {
                case 1: successHandler(value); break;
                case 2: errorHandler(error); break;
                default: throw new InvalidOperationException();
            }
        }

        private static object Case(Result<T> u)
        {
            switch (u.tag)
            {
                case 1: return u.value;
                case 2: return u.error;
                default: throw new InvalidOperationException();
            }
        }
    }
}
