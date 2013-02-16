using log4net;
using Ordering.Data.Common;

namespace Ordering.Data.DataAccess
{
    public class OrderItemDataControl : BaseDataControl<OrderItem>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(OrderItemDataControl));
        private static readonly object _lockOrderItemDataControl = new object();

        private static OrderItemDataControl _orderItemDataControl;
        public static OrderItemDataControl Instance
        {
            get
            {
                lock (_lockOrderItemDataControl)
                {
                    if (_orderItemDataControl == null)
                        _orderItemDataControl = new OrderItemDataControl();
                }

                return _orderItemDataControl;
            }
        }

        private OrderItemDataControl()
        {
            _log.InfoFormat("{0} is created", this.GetType());
        }
    }
}