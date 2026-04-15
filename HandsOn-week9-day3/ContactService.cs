using ContactService.Models;
using ContactService.Repository;

namespace ContactService.Services
{
    public class ContactServiceClass
    {
        private readonly IContactRepository _repo;

        public ContactServiceClass(IContactRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Contact>> GetAll() => _repo.GetAll();
        public Task<Contact> GetById(int id) => _repo.GetById(id);
        public Task<Contact> Add(Contact contact) => _repo.Add(contact);
        public Task<Contact> Update(Contact contact) => _repo.Update(contact);
        public Task<bool> Delete(int id) => _repo.Delete(id);
    }
}
