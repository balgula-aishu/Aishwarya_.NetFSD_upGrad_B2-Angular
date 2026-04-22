using System.Collections.Generic;

namespace week10_day1
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        bool DeleteContact(int id);
        List<Contact> GetAllContacts();
    }
}