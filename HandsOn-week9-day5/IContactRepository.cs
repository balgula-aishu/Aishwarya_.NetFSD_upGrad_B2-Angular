using System.Collections.Generic;

namespace ContactManagement.Core
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        List<Contact> GetAll();
        bool Delete(int id);
    }
}
