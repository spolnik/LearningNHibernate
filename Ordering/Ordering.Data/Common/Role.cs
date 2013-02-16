using System.Collections.Generic;

namespace Ordering.Data.Common
{
    public class Role : BaseComponent
    {
        public Role()
        {
        }

        public Role(string name, string description)
        {
            this._name = name;
            this._description = description;
        }

        private string _name;
        public virtual string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private string _description;
        public virtual string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        private IList<Login> _logins;
        public virtual IList<Login> Logins
        {
            get { return this._logins ?? (this._logins = new List<Login>()); }
            set { this._logins = value; }
        }
    }
}