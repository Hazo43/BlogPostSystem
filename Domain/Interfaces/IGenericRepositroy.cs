using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepositroy<TEntity , TKey> where TEntity : BaseEntity<TKey>
    {
        // GetAll
        Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracing = false);

        //GetById
        Task<TEntity?> GetByIdAsync(TKey id);

        //Delete
        void Delete (TEntity entity);

        //AddAsync
        Task AddAsync(TEntity entity);

        //Update
        void Update (TEntity entity);
    }
}
