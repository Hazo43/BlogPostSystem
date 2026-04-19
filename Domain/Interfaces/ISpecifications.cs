using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISpecifications<TEntity , TKey> where TEntity : BaseEntity<TKey>
    {
        // where
        public Expression<Func<TEntity , bool>>? Criteria {  get; }
        // Include
        public List<Expression<Func<TEntity , object>>> IncludeExpression { get; }
        // OrderBy
        public Expression<Func<TEntity, object>> OrderBy { get;}
        // OrderByDesc
        public Expression<Func<TEntity , object>> OrderByDesc { get;}
   
        // Pagination ( Take , Skip )
        public int Skip { get; }
        public int Take { get; }
        public bool IsPaginated { get; }



    }
}
