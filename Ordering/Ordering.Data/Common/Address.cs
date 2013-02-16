using System.Collections.Generic;

namespace Ordering.Data.Common
{
    public class Address : BaseComponent
    {
        public Address()
        {
        }

        public Address(string address1, string address2, string city, string state, string zip)
        {
            this._address1 = address1;
            this._address2 = address2;
            this._city = city;
            this._state = state;
            this._zip = zip;
        }

        private string _address1;
        public virtual string Address1
        {
            get { return this._address1; }
            set { this._address1 = value; }
        }

        private string _address2;
        public virtual string Address2
        {
            get { return this._address2; }
            set { this._address2 = value; }
        }

        private string _city;
        public virtual string City
        {
            get { return this._city; }
            set { this._city = value; }
        }

        private string _state;
        public virtual string State
        {
            get { return this._state; }
            set { this._state = value; }
        }

        private string _zip;
        public virtual string Zip
        {
            get { return this._zip; }
            set { this._zip = value; }
        }

        private Contact _contact;
        public virtual Contact Contact
        {
            get { return this._contact; }
            set
            {
                this._contact = value;
                
                if (!value.Addresses.Contains(this))
                    value.Addresses.Add(this);
            }
        }

        private IList<OrderHeader> _billToOrderHeaders;
        public virtual IList<OrderHeader> BillToOrderHeaders
        {
            get { return this._billToOrderHeaders ?? (this._billToOrderHeaders = new List<OrderHeader>()); }
            set { this._billToOrderHeaders = value; }
        }

        private IList<OrderHeader> _shipToOrderHeaders;
        public virtual IList<OrderHeader> ShipToOrderHeaders
        {
            get { return this._shipToOrderHeaders ?? (this._shipToOrderHeaders = new List<OrderHeader>()); }
            set { this._shipToOrderHeaders = value; }
        }
    }
}