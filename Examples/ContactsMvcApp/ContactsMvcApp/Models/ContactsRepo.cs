using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsMvcApp.Models
{
    public class ContactsRepo
    {
        private TrainingDataContext context = new TrainingDataContext();

        public List<Contact> GetAllContacts()
        {
            return context.Contacts.ToList();
        }

        public Contact GetContactById(int id)
        {
            return context.Contacts.ToList().First(c => c.ContactID == id);
        }

        public void AddNewContact(Contact contact)
        {
            // contact is added to an in-memory table (middleware)
            context.Contacts.InsertOnSubmit(contact);
            // the changes to the context, will now be updated to the actual DB
            context.SubmitChanges();
        }

        public void UpdateContact(Contact contact)
        {
            // c1 is an object reference to an entity in the "context"
            // changes to this object will automatically be written to the db while commit.
            Contact c1 = GetContactById(contact.ContactID);
            if (c1 != null)
            {
                c1.FirstName = contact.FirstName;
                c1.LastName = contact.LastName;
                c1.City = contact.City;
                c1.Country = contact.Country;
                c1.Email = contact.Email;
                c1.Phone = contact.Phone;
                context.SubmitChanges();
            }
        }

        public void DeleteContact(int id)
        {
            Contact c1 = GetContactById(id);
            if (c1 != null)
            {
                context.Contacts.DeleteOnSubmit(c1);
                context.SubmitChanges();
            }
        }

        public List<Contact> GetContactsFromCity(string city)
        {
            return context.Contacts.Where(c => c.City == city).ToList();
        }
    }
}