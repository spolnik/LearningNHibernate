using System;
using System.Collections.Generic;
using log4net;
using NHibernate;
using NHibernate.Criterion;
using Ordering.Data.Common;
using Ordering.Data.Utils;

namespace Ordering.Data.DataAccess
{
    public class BaseDataControl<T> where T : BaseComponent
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(BaseDataControl<T>));
        private ICriteria _criteria;

        protected ISession OpenSession()
        {
            return SessionProvider.Instance.SessionFactory.OpenSession();
        }

        public int Save(T contact)
        {
            try
            {
                return this.SaveOrUpdateContact(contact);
            }
            catch (Exception e)
            {
                _log.Error(e);
                throw;
            }
        }

        public void Delete(T contact)
        {
            try
            {
                this.DeleteContact(contact);
            }
            catch (Exception e)
            {
                _log.Error(e);
                throw;
            }
        }

        public void Refresh(T contact)
        {
            using (var session = this.OpenSession())
            {
                session.Refresh(contact);
            }
        }

        public T GetById(int id)
        {
            using (var session = this.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public IList<T> GetAll()
        {
            using (var session = this.OpenSession())
            {
                var criteria = session.CreateCriteria<T>();
                return criteria.List<T>();
            }
        }

        public IList<T> GetAll(PagingAndSortingArguments pagingAndSortingArgs)
        {
            using (var session = this.OpenSession())
            {
                ICriteriaHelper criteriaHelper = new CriteriaHelper(session.CreateCriteria<Contact>());

                criteriaHelper.CheckAndAddOrderToCriteria(pagingAndSortingArgs.SortExpression);
                criteriaHelper.SetFirstResultAndMaxResults(pagingAndSortingArgs.FirstResult, pagingAndSortingArgs.MaxResults);

                return criteriaHelper.List<T>();
            }
        }

        public int GetCountOfAll()
        {
            using (var session = this.OpenSession())
            {
                var criteria = session.CreateCriteria<T>();
                int countOfAll = (int)criteria.SetProjection(Projections.RowCount()).UniqueResult();

                return countOfAll;
            }
        }

        private void DeleteContact(T contact)
        {
            using (var session = this.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(contact);
                    transaction.Commit();
                }
            }
        }

        private int SaveOrUpdateContact(T contact)
        {
            using (var session = this.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(contact);
                    transaction.Commit();
                    return contact.Id;
                }
            }
        }
    }
}