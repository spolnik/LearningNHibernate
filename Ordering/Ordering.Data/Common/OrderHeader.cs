using System;
using System.Collections.Generic;

namespace Ordering.Data.Common
{
    public class OrderHeader : BaseComponent
    {
        public OrderHeader()
        {
        }

        public OrderHeader(string number, DateTime orderDate, int itemQty, decimal total, Contact billToContact, Contact shipToContact, Address billToAddress, Address shipToAddress)
        {
            this._number = number;
            this._orderDate = orderDate;
            this._itemQty = itemQty;
            this._total = total;
            this._billToContact = billToContact;
            this._shipToContact = shipToContact;
            this._billToAddress = billToAddress;
            this._shipToAddress = shipToAddress;
        }

        private string _number;
        public virtual string Number
        {
            get { return this._number; }
            set { this._number = value; }
        }

        private DateTime _orderDate;
        public virtual DateTime OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        private int _itemQty;
        public virtual int ItemQty
        {
            get { return this._itemQty; }
            set { this._itemQty = value; }
        }

        private decimal _total;
        public virtual decimal Total
        {
            get { return this._total; }
            set { this._total = value; }
        }

        private Contact _billToContact;
        public virtual Contact BillToContact
        {
            get { return this._billToContact; }
            set { this._billToContact = value; }
        }

        private Contact _shipToContact;
        public virtual Contact ShipToContact
        {
            get { return this._shipToContact; }
            set { this._shipToContact = value; }
        }

        private Address _billToAddress;
        public virtual Address BillToAddress
        {
            get { return this._billToAddress; }
            set { this._billToAddress = value; }
        }

        private Address _shipToAddress;
        public virtual Address ShipToAddress
        {
            get { return this._shipToAddress; }
            set { this._shipToAddress = value; }
        }

        private IList<OrderItem> _orderItems;
        public virtual IList<OrderItem> OrderItems
        {
            get { return this._orderItems ?? (this._orderItems = new List<OrderItem>()); }
            set { this._orderItems = value; }
        }
    }
}