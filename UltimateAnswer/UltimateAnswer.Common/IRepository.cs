using System.Collections.Generic;
using System.Threading.Tasks;

namespace UltimateAnswer.Common
{
    public interface IRepository<TId, TEntity>
    {
        Task<Result<TId>> Create(TEntity entity);
        Task<Result<TEntity>> Retrieve(TId id);
        Task<Result<List<TEntity>>> RetrieveAll();
        Task<Result<bool>> Update(TId id, TEntity entity);
        Task<Result<bool>> Delete(TId id);
    }
}