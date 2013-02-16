using log4net;
using Ordering.Data.Common;

namespace Ordering.Data.DataAccess
{
    public class OrderHeaderDataControl : BaseDataControl<OrderHeader>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(OrderHeaderDataControl));
        private static readonly object _lockOrderHeaderDataControl = new object();

        private static OrderHeaderDataControl _orderHeaderDataControl;
        public static OrderHeaderDataControl Instance
        {
            get
            {
                lock (_lockOrderHeaderDataControl)
                {
                    if (_orderHeaderDataControl == null)
                        _orderHeaderDataControl = new OrderHeaderDataControl();
                }

                return _orderHeaderDataControl;
            }
        }

        private OrderHeaderDataControl()
        {
            _log.InfoFormat("{0} is created", this.GetType());
        }
    }
}