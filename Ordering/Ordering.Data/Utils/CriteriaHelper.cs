using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace Ordering.Data.Utils
{
    public class CriteriaHelper : ICriteriaHelper
    {
        private const string DescendingId = "DESC";
        private readonly ICriteria _criteria;

        public CriteriaHelper(ICriteria criteria)
        {
            this._criteria = criteria;
        }

        public void SetFirstResultAndMaxResults(int firstResult, int maxResults)
        {
            if (firstResult != 0)
                this._criteria.SetFirstResult(firstResult);

            if (maxResults != 0)
                this._criteria.SetMaxResults(maxResults);
        }

        public void CheckAndAddOrderToCriteria(string sortExpression)
        {
            if (String.IsNullOrEmpty(sortExpression))
                return;

            string[] sort = sortExpression.Split(' ');
            bool ascending = true;

            if (IsDescending(sort))
                ascending = false;

            this._criteria.AddOrder(new Order(sort[0], ascending));
        }

        public IList<T> List<T>()
        {
            return this._criteria.List<T>();
        }

        private static bool IsDescending(string[] sort)
        {
            return sort.Length > 1 && sort[1].ToUpper() == DescendingId;
        }
    }
}