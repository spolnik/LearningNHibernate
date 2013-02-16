using System;
using log4net;
using NHibernate.Criterion;
using Ordering.Data.Common;

namespace Ordering.Data.DataAccess
{
    public class LoginDataControl : BaseDataControl<Login>
    {
        #region Field Names

        public struct FieldNames
        {
            public const string Id = "Id";
            public const string Active = "Active";
            public const string LastName = "LastName";
            public const string FirstName = "FirstName";
            public const string Email = "Email";
            public const string UserName = "UserName";
            public const string Password = "Password";
            public const string PasswordQuestion = "PasswordQuestion";
            public const string PasswordAnswer = "PasswordAnswer";
            public const string Salt = "Salt";
        }

        #endregion

        private static readonly ILog _log = LogManager.GetLogger(typeof(AddressDataControl));
        private static readonly object _lockLoginDataControl = new object();

        private static LoginDataControl _loginDataControl;
        public static LoginDataControl Instance
        {
            get
            {
                lock (_lockLoginDataControl)
                {
                    if (_loginDataControl == null)
                        _loginDataControl = new LoginDataControl();
                }

                return _loginDataControl;
            }
        }

        private LoginDataControl()
        {
            _log.InfoFormat("{0} is created", this.GetType());
        }

        public Login GetByUserName(string username)
        {
            using (var session = this.OpenSession())
            {
                var criteria = session.CreateCriteria<Login>();
                criteria.Add(Restrictions.Eq(FieldNames.UserName, username));

                return criteria.UniqueResult<Login>();
            }
        }
    }
}