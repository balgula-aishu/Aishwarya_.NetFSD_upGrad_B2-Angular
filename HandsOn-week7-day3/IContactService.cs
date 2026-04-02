using Contact_Management_App.Models;

namespace Contact_Management_App.Services
{
    public interface IContactService
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
    }
}
