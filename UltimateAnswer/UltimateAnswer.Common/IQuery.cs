namespace UltimateAnswer.Common
{
    public interface
        IQuery<in TRequest, TResponse> : IAppService<TRequest, TResponse>
    {
    }
}