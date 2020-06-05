using System;

namespace HTTPbin.Common
{
    /// <summary>
    /// A Displayer is used to display the result of a use case that changes the
    /// displayed view.
    /// </summary>
    public interface IDisplayer<in T>
    {
        /// <summary>
        /// Display the specified value.
        /// </summary>
        /// <param name="value">The value to display.</param>
        /// <param name="requestCode">To distinguish similar requests.</param>
        void Display(T value, int requestCode = 0);

        /// <summary>
        /// Display the specified error.
        /// </summary>
        /// <param name="error">The error to display.</param>
        void Display(Exception error);
    }
}