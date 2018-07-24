using System;

namespace CleanArchRecipe.Common
{
    public class Response<T>
    {
        public T Success { get; set; }
        public Exception Failure { get; set; }
    }
}