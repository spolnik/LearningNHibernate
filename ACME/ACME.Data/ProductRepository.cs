using System;
using ACME.Model;
using ACME.Repository;
using NHibernate;

namespace ACME.Data
{
    public class ProductRepository : IProductRepository
    {
        #region IProductRepository Members

        public Product GetById(int? id)
        {
            using (ISession session = GetSession())
            {
                var product = session.Get<Product>(id);
                NHibernateUtil.Initialize(product.Categories);
                return product;
            }
        }

        public void Save(Product saveObj)
        {
            using (ISession session = GetSession())
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    session.SaveOrUpdate(saveObj);
                    trans.Commit();
                }
            }
        }

        public void Delete(Product delObj)
        {
            using (ISession session = GetSession())
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    session.Delete(delObj);
                    trans.Commit();
                }
            }
        }

        public void SaveUOM(UnitOfMeasure saveObj)
        {
            using (var session = GetSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    session.SaveOrUpdate(saveObj);
                    trans.Commit();
                }
            }
        }

        public void SaveCategory(Category saveObj)
        {
            using (var session = GetSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    session.SaveOrUpdate(saveObj);
                    trans.Commit();
                }
            }
        }

        #endregion

        private static ISession GetSession()
        {
            return SessionProvider.SessionFactory.OpenSession();
        }
    }
}