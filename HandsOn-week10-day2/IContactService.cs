
using System.Collections.Generic;
using week10_day2;

namespace week10_day2.Services
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        void Add(Contact contact);
        void Update(Contact contact);
        bool Delete(int id);
    }
}