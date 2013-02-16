using System.Collections.Generic;
using log4net;
using NHibernate.Criterion;
using Ordering.Data.Common;

namespace Ordering.Data.DataAccess
{
    public class ContactDataControl : BaseDataControl<Contact>
    {
        #region Field Names

        public struct FieldNames
        {
            public const string Id = "Id";
            public const string LastName = "LastName";
            public const string FirstName = "FirstName";
            public const string Email = "Email";
            public const string Addresses = "Addresses";
            public const string Phones = "Phones";
            public const string BillToOrderHeaders = "BillToOrderHeaders";
            public const string ShipToOrderHeaders = "ShipToOrderHeaders";
        }

        #endregion

        private static readonly ILog _log = LogManager.GetLogger(typeof(ContactDataControl));
        private static readonly object _lockContactDataControl = new object();

        private static ContactDataControl _contactDataControl;
        public static ContactDataControl Instance
        {
            get
            {
                lock (_lockContactDataControl)
                {
                    if (_contactDataControl == null)
                        _contactDataControl = new ContactDataControl();
                }

                return _contactDataControl;
            }
        }

        public ContactDataControl()
        {
            _log.InfoFormat("{0} is created", this.GetType());
        }

        public IList<Contact> GetByState(string state)
        {
            using (var session = this.OpenSession())
            {
                var criteria = session.CreateCriteria<Contact>();
                criteria.CreateCriteria(FieldNames.Addresses).Add(Restrictions.Eq(AddressDataControl.FieldNames.State, state));

                return criteria.List<Contact>();
            }
        }
    }
}