using Domain.Entites;
using Domain.Interfaces;
using Persistence.Data.DbContexts;
using Persistence.Repositories;

namespace Persistence.unitofwork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _dbContext;
        private Dictionary<string, object> _repository = [];
        public UnitOfWork(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenericRepositroy<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            // get Entity => BlogPost
            var entryTypeOfKey = typeof(TEntity).Name;

            // روح اعملو واحده جديده Entity لو مش بيحتوي علي
            if (!_repository.ContainsKey(entryTypeOfKey))
                _repository[entryTypeOfKey] = new GenericRepositroy<TEntity, TKey>(_dbContext);

            // Entity لو بيحتوي روح رجعهلو ال
            return (IGenericRepositroy<TEntity, TKey>)_repository[entryTypeOfKey];
        }

        public async Task<int> SaveChanges()
        => await _dbContext.SaveChangesAsync();
    }
}
