using log4net;
using Ordering.Data.Common;

namespace Ordering.Data.DataAccess
{
    public class PhoneDataControl : BaseDataControl<Phone>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(PhoneDataControl));
        private static readonly object _lockPhoneDataControl = new object();

        private static PhoneDataControl _phoneDataControl;
        public static PhoneDataControl Instance
        {
            get
            {
                lock (_lockPhoneDataControl)
                {
                    if (_phoneDataControl == null)
                        _phoneDataControl = new PhoneDataControl();
                }

                return _phoneDataControl;
            }
        }

        private PhoneDataControl()
        {
            _log.InfoFormat("{0} is created", this.GetType());
        }
    }
}