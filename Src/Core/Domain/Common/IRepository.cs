using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IRepository<TEntity> where TEntity : AuditableSoftDeletableEntity, new()
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void SaveChanges();
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetQueryable();
    }
}
