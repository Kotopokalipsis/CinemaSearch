using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedKernel.Interfaces
{
    public interface IRepository<TEntity> where TEntity: BaseEntity
    {
        public Task<List<TEntity>> GetListAsync();
    }
}