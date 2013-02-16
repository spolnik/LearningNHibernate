using System.Collections.Generic;

namespace Ordering.Data.Common
{
    public class Login : BaseComponent
    {
        public Login()
        {
        }

        public Login(string lastName, string firstName, string email, string userName, string password, string passwordQuestion, string passwordAnswer, string salt)
        {
            this._active = false;
            this._lastName = lastName;
            this._firstName = firstName;
            this._email = email;
            this._userName = userName;
            this._password = password;
            this._passwordQuestion = passwordQuestion;
            this._passwordAnswer = passwordAnswer;
            this._salt = salt;
        }

        private bool _active;
        public virtual bool Active
        {
            get { return this._active; }
            set { this._active = value; }
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

        private string _userName;
        public virtual string UserName
        {
            get { return this._userName; }
            set { this._userName = value; }
        }

        private string _password;
        public virtual string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

        private string _passwordQuestion;
        public virtual string PasswordQuestion
        {
            get { return this._passwordQuestion; }
            set { this._passwordQuestion = value; }
        }

        private string _passwordAnswer;
        public virtual string PasswordAnswer
        {
            get { return this._passwordAnswer; }
            set { this._passwordAnswer = value; }
        }

        private string _salt;
        public virtual string Salt
        {
            get { return this._salt; }
            set { this._salt = value; }
        }

        private IList<Role> _roles;
        public virtual IList<Role> Roles
        {
            get { return this._roles ?? (this._roles = new List<Role>()); }
            set { this._roles = value; }
        }
    }
}