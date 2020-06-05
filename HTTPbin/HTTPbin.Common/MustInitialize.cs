namespace HTTPbin.Common
{
    /// <summary>
    /// Force an implementing class to initialize a parameter of a given type.
    /// </summary>
    public abstract class MustInitialize<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BasicCleanArch.MustInitialize`1"/> class.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        protected MustInitialize(T parameters)
        {
        }
    }
}