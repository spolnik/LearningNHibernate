using System.Collections.Generic;

namespace Ordering.Data.Common
{
    public class Contact : BaseComponent
    {
        public Contact()
        {
        }

        public Contact(string lastName, string firstName, string email)
        {
            this._lastName = lastName;
            this._firstName = firstName;
            this._email = email;
        }

        private string _lastName;
        public virtual string LastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }

        private string _firstName;
        public virtual string FirstName
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }

        private string _email;
        public virtual string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        private IList<Address> _addresses;
        public virtual IList<Address> Addresses
        {
            get { return this._addresses ?? (this._addresses = new List<Address>()); }
            set { this._addresses = value; }
        }

        private IList<Phone> _phones;
        public virtual IList<Phone> Phones
        {
            get { return this._phones ?? (this._phones = new List<Phone>()); }
            set { this._phones = value; }
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