namespace Ordering.Data.Common
{
    public class OrderItem : BaseComponent
    {
        public OrderItem()
        {
        }

        public OrderItem(string productName, int quantity, OrderHeader orderHeader)
        {
            this._productName = productName;
            this._quantity = quantity;
            this._orderHeader = orderHeader;
        }

        private string _productName;
        public virtual string ProductName
        {
            get { return this._productName; }
            set { this._productName = value; }
        }

        private int _quantity;
        public virtual int Quantity
        {
            get { return this._quantity; }
            set { this._quantity = value; }
        }

        private OrderHeader _orderHeader;
        public virtual OrderHeader OrderHeader
        {
            get { return this._orderHeader; }
            set { this._orderHeader = value; }
        }
    }
}