
using week9_day2.Models;

namespace week9_day2.Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
    }
}