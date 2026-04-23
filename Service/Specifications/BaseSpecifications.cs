using Domain.Entites;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Service.Specifications
{
    public class BaseSpecifications<TEntity, Tkey> : ISpecifications<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        #region Criteria => Where 
        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }
        // where عشان اجبر كلو يستخدم ال constractor عملتها جوا
        protected BaseSpecifications(Expression<Func<TEntity, bool>>? criteriaExpression)
        {
            Criteria = criteriaExpression;
        }
        #endregion

        #region Include - IncludeStrings

        public List<Expression<Func<TEntity, object>>> IncludeExpression { get; } = new();
        protected void AddInclude(Expression<Func<TEntity, object>> IncludeExp)
        {
            IncludeExpression.Add(IncludeExp);
        }

    // AddInclude("BlogPostTags.Tag"); هكذا  GetAll and GetById مع ال Include عشان نعملهم  Tags عملناها عشان ال
        public List<string> IncludeStrings { get; } = new();
        protected void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
        #endregion

        #region Sorting => { OrderBy - OrderByDesc }


        public Expression<Func<TEntity, object>> OrderBy { get; private set; }
        protected void AddOrderBy(Expression<Func<TEntity, object>> OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }

        public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }
        protected void AddOrderByDesc(Expression<Func<TEntity, object>> OrderByDescExpression)
        {
            OrderByDesc = OrderByDescExpression;
        }

        #endregion


        #region Pagination [ Take - Skip ]

        public int Skip { get; private set; }

        public int Take { get; private set; }

        public bool IsPaginated { get; private set; }

        protected void ApplyPagination(int pageSize, int pageIndex)
        {
            IsPaginated = true;
            Take = pageSize;
            Skip = (pageIndex - 1) * pageSize;
        }


        #endregion

    }
}
