using System;
using System.Collections.Generic;
using System.Linq;
using week10_day1;

namespace week10_day1
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new();

        public void AddContact(Contact contact)
        {
            ValidateContact(contact);

            if (_contacts.Any(c => c.Id == contact.Id))
            {
                throw new InvalidOperationException("Contact with same Id already exists.");
            }

            _contacts.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            ValidateContact(contact);

            var existing = _contacts.FirstOrDefault(c => c.Id == contact.Id);

            if (existing == null)
            {
                throw new KeyNotFoundException("Contact not found.");
            }

            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
        }

        public bool DeleteContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
                return false;

            return _contacts.Remove(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        // ✔ Separate validation (reduces duplication)
        private static void ValidateContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new ArgumentException("Name is required.");

            if (string.IsNullOrWhiteSpace(contact.Email))
                throw new ArgumentException("Email is required.");
        }
    }
}