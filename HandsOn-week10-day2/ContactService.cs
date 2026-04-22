
using System.Collections.Generic;
using week10_day2;
using week10_day2.Repositories;
using week10_day2.Services;

namespace week10_day2.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public List<Contact> GetAll() => _repo.GetAll();

        public Contact GetById(int id) => _repo.GetById(id);

        public void Add(Contact contact)
        {
            if (contact == null)
                throw new Exception("Contact is null");

            _repo.Add(contact);
        }

        public void Update(Contact contact)
        {
            _repo.Update(contact);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
