using log4net;
using Ordering.Data.Common;

namespace Ordering.Data.DataAccess
{
    public class AddressDataControl : BaseDataControl<Address>
    {
        #region Field Names

        public struct FieldNames
        {
            public const string Id = "Id";
            public const string Address1 = "Address1";
            public const string Address2 = "Address2";
            public const string City = "City";
            public const string State = "State";
            public const string Zip = "Zip";
        }

        #endregion

        private static readonly ILog _log = LogManager.GetLogger(typeof(AddressDataControl));
        private static readonly object _lockAddressDataControl = new object();

        private static AddressDataControl _addressDataControl;
        public static AddressDataControl Instance
        {
            get
            {
                lock (_lockAddressDataControl)
                {
                    if (_addressDataControl == null)
                        _addressDataControl = new AddressDataControl();
                }

                return _addressDataControl;
            }
        }

        private AddressDataControl()
        {
            _log.InfoFormat("{0} is created", this.GetType());
        }
    }
}