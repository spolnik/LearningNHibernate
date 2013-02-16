using System.Collections.Generic;

namespace Ordering.Data.Utils
{
    public interface ICriteriaHelper
    {
        void SetFirstResultAndMaxResults(int firstResult, int maxResults);

        void CheckAndAddOrderToCriteria(string sortExpression);

        IList<T> List<T>();
    }
}