using System.Collections.Generic;

namespace Ordering.Data.Common
{
    public class Phone : BaseComponent
    {
        public Phone()
        {
        }

        public Phone(string number, int phoneType)
        {
            this._number = number;
            this._phoneType = phoneType;
        }

        private string _number;
        public virtual string Number
        {
            get { return this._number; }
            set { this._number = value; }
        }

        private int _phoneType;
        public virtual int PhoneType
        {
            get { return this._phoneType; }
            set { this._phoneType = value; }
        }

        private IList<Contact> _contacts;
        public virtual IList<Contact> Contacts
        {
            get { return this._contacts ?? (this._contacts = new List<Contact>()); }
            set { this._contacts = value; }
        }
    }
}