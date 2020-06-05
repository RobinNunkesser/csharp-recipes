using System;

namespace HTTPbin.Common
{
    /// <summary>
    /// Class associated with a result or an error.
    /// </summary>
    public class Result<T>
    {
        private readonly Exception _error;
        private readonly int _tag;
        private readonly T _value;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="T:BasicCleanArch.Result`1"/> class with a value.
        /// </summary>
        /// <param name="value">A value.</param>
        public Result(T value)
        {
            _value = value;
            _tag = 1;
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="T:BasicCleanArch.Result`1"/> class with an error.
        /// </summary>
        /// <param name="error">An error.</param>
        public Result(Exception error)
        {
            _error = error;
            _tag = 2;
        }

        /// <summary>
        /// Match the encapsulated result to a lambda expression, depending on
        /// it being a value or an error.
        /// </summary>
        /// <param name="successHandler">Success handler.</param>
        /// <param name="errorHandler">Error handler.</param>
        public virtual void Match(Action<T> successHandler,
            Action<Exception> errorHandler)
        {
            if (successHandler == null)
                throw new ArgumentNullException(nameof(successHandler));
            if (errorHandler == null)
                throw new ArgumentNullException(nameof(errorHandler));

            switch (_tag)
            {
                case 1:
                    successHandler(_value);
                    break;
                case 2:
                    errorHandler(_error);
                    break;
                default: throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Returns the encapsulated result.
        /// </summary>
        /// <returns>A value or an error</returns>
        /// <param name="result">The result.</param>
        private static object Case(Result<T> result)
        {
            switch (result._tag)
            {
                case 1: return result._value;
                case 2: return result._error;
                default: throw new InvalidOperationException();
            }
        }
    }
}