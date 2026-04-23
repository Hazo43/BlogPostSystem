using Domain.Entites;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class SpecificationsEvaluator
    {
        public static IQueryable<TEntity> CrateQuery<TEntity , TKey> (IQueryable<TEntity> EntryPoint
                  , ISpecifications<TEntity , TKey> specifications) where TEntity : BaseEntity<TKey>
        {
            var query = EntryPoint;

            if(specifications is not null)
            {
                // where 
                if( specifications.Criteria is not null )
                    query = query.Where(specifications.Criteria);
                
                // OrderBy
                if(specifications.OrderBy is not null )
                    query = query.OrderBy(specifications.OrderBy);
                
                // OrderByDesc
                if(specifications.OrderByDesc is not null)
                    query = query.OrderByDescending(specifications.OrderByDesc);
                
                // Include 
                if(specifications.IncludeExpression is not null && specifications.IncludeExpression.Count() > 0)
                {
                    query = specifications.IncludeExpression.Aggregate(query,
                        (CurrentQuery, IncludeExp) => CurrentQuery.Include(IncludeExp));
                }
                
                // IncludeStrings
                if (specifications.IncludeStrings is not null && specifications.IncludeStrings.Any())
                {
                    query = specifications.IncludeStrings.Aggregate(query,
                        (CurrentQuery, IncludeStr) => CurrentQuery.Include(IncludeStr));
                }

                // Paginations 
                if (specifications.IsPaginated is true) // و عاوز يستخدمها IsPaginated معناها ان هو وصل ل true لو ب
                    query = query.Skip(specifications.Skip).Take(specifications.Take);
            }
            return query;
        }
    }
}
