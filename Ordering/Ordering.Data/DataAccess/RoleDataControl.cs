using System;
using System.Collections;
using System.Collections.Generic;
using log4net;
using NHibernate.Criterion;
using Ordering.Data.Common;

namespace Ordering.Data.DataAccess
{
    public class RoleDataControl : BaseDataControl<Role>
    {
        #region Field Names

        public struct FieldNames
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string Description = "Description";
            public const string Logins = "Logins";
        }

        #endregion

        private static readonly ILog _log = LogManager.GetLogger(typeof(RoleDataControl));
        private static readonly object _lockRoleDataControl = new object();

        private static RoleDataControl _roleDataControl;
        public static RoleDataControl Instance
        {
            get
            {
                lock (_lockRoleDataControl)
                {
                    if (_roleDataControl == null)
                        _roleDataControl = new RoleDataControl();
                }

                return _roleDataControl;
            }
        }

        private RoleDataControl()
        {
            _log.InfoFormat("{0} is created", this.GetType());
        }

        public IList<Role> GetRolesByUserName(string username)
        {
            using (var session = this.OpenSession())
            {
                var criteria = session.CreateCriteria<Role>();
                criteria.CreateCriteria(FieldNames.Logins).Add(Restrictions.Eq(LoginDataControl.FieldNames.UserName, username));

                return criteria.List<Role>();
            }
        }
    }
}