using System;

namespace UltimateAnswer.Common
{
    /// <summary>
    /// An App Service executes the business logic of a use case.
    /// </summary>
    public interface IAppService<in TRequest, TResponse>
    {
        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="request">Encapsulated request parameters.</param>
        /// <param name="successHandler">The action to use for a successful result.</param>
        /// <param name="errorHandler">The action to use for an unsuccessful result.</param>
        void Execute(TRequest request, Action<TResponse> successHandler,
            Action<Exception> errorHandler);
    }
}