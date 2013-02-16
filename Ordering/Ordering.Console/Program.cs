using System.Collections.Generic;
using Ordering.Data.Common;
using Ordering.Data.DataAccess;

namespace Ordering.Console
{
    class Program
    {
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();

            SessionProvider.Instance.RegenerateSchema();

            Contact contact1 = new Contact("Martha", "Washington", "mw@usa.gov");
            Contact contact2 = new Contact("Tom", "Washington", "tw@gb.gov");
            Contact contact3 = new Contact("Martha", "Wash", "mw@poland.gov");
            
            ContactDataControl.Instance.Save(contact1);
            ContactDataControl.Instance.Save(contact2);
            ContactDataControl.Instance.Save(contact3);

            IList<Contact> contacts = ContactDataControl.Instance.GetAll();
            DisplayContacts(contacts);

            contacts = ContactDataControl.Instance.GetAll(new PagingAndSortingArguments(0, 1, string.Empty));
            System.Console.WriteLine("-----------");
            DisplayContacts(contacts);
        }

        private static void DisplayContacts(IEnumerable<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                System.Console.WriteLine("FirstName: {0}, LastName: {1}, Email: {2}",
                                         contact.FirstName, contact.LastName, contact.Email);
            }
        }
    }
}
