
using System.Collections.Generic;
using System.Linq;
using week10_day2;
using week10_day2.Repositories;

namespace week10_day2.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new();

        public List<Contact> GetAll() => _contacts;

        public Contact GetById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            var existing = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existing != null)
            {
                existing.Name = contact.Name;
                existing.Email = contact.Email;
                existing.Phone = contact.Phone;
            }
        }

        public bool Delete(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null) return false;

            _contacts.Remove(contact);
            return true;
        }
    }
}