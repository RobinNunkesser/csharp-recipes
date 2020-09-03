using System;

namespace UltimateAnswer.Common
{
    /// <summary>
    /// A Command Handler executes the business logic of a use case.
    /// </summary>
    public interface ICommandHandler<in TInDTO, TOutDTO>
    {
        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="inDTO">Encapsulated inDTO parameters.</param>
        /// <param name="successHandler">The action for a successful result.</param>
        /// <param name="errorHandler">The action for an unsuccessful result.</param>
        void Execute(TInDTO inDTO, Action<TOutDTO> successHandler,
            Action<Exception> errorHandler);
    }
}