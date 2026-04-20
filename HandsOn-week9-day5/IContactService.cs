using System.Collections.Generic;

namespace ContactManagement.Core
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Contact> GetContacts();
        bool RemoveContact(int id);
    }
}
