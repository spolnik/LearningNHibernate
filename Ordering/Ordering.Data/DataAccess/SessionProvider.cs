using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Ordering.Data.DataAccess
{
    public sealed class SessionProvider
    {
        private static readonly SessionProvider _instance;
        private readonly ISessionFactory _sessionFactory;
        private readonly Configuration _cfg;

        static SessionProvider()
        {
            _instance = new SessionProvider();
        }

        private SessionProvider()
        {
            this._cfg = new Configuration();
            this._cfg.Configure();

            this._sessionFactory = this._cfg.BuildSessionFactory();
        }

        public static SessionProvider Instance
        {
            get { return _instance; }
        }

        public void RegenerateSchema()
        {
            var schema = new SchemaExport(this._cfg);
            schema.Create(false, true);
        }

        public ISessionFactory SessionFactory
        {
            get { return this._sessionFactory; }
        }
    }
}