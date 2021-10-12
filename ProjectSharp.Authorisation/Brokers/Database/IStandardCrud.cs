using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectSharp.Authorisation.Brokers.Database
{
    public interface IStandardCrud<TEntity>
    {
        ValueTask<TEntity> InsertAsync(TEntity entity);

        IEnumerable<TEntity> FindAllAsync();

        ValueTask<TEntity> FindByIdAsync(string entity);

        ValueTask<TEntity> UpdateAsync(TEntity entity);

        ValueTask<TEntity> DeleteAsync(TEntity entity);
    }
}