using Domain.Common;

namespace DataLayer.Postgre.Common
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : AuditableSoftDeletableEntity, new()
    {
        protected readonly ApplicationContext dbContext;

        public EfRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(TEntity entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
        public TEntity Get(long id)
        {
            return dbContext.Set<TEntity>().FirstOrDefault(c => c.Id == id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> GetByNumber(int count)
        {
            return dbContext.Set<TEntity>().OrderByDescending(u => u.CreatedDate).Take(count).ToList();
        }
        public IQueryable<TEntity> GetQueryable()
        {
            return dbContext.Set<TEntity>().AsQueryable();
        }
    }
}
