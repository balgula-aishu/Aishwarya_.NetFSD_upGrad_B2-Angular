
using Microsoft.Extensions.Caching.Memory;
using week9_day2.DTOs;
using week9_day2.Models;
using week9_day2.Repository;

namespace week9_day2.Services
{
    public class ContactService
    {
        private readonly IContactRepository _repo;
        private readonly IMemoryCache _cache;

        public ContactService(IContactRepository repo, IMemoryCache cache)
        {
            _repo = repo;
            _cache = cache;
        }

        // GET ALL WITH PAGING + CACHE
        public async Task<PagedResponse<Contact>> GetAll(int pageNumber, int pageSize)
        {
            string cacheKey = $"contacts_{pageNumber}_{pageSize}";

            if (!_cache.TryGetValue(cacheKey, out PagedResponse<Contact> cachedData))
            {
                var contacts = await _repo.GetAll();

                var totalRecords = contacts.Count;
                var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                var data = contacts
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                cachedData = new PagedResponse<Contact>
                {
                    TotalRecords = totalRecords,
                    TotalPages = totalPages,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    Data = data
                };

                _cache.Set(cacheKey, cachedData, TimeSpan.FromSeconds(60));
            }

            return cachedData;
        }

        // GET BY ID WITH CACHE
        public async Task<Contact> GetById(int id)
        {
            string cacheKey = $"contact_{id}";

            if (!_cache.TryGetValue(cacheKey, out Contact contact))
            {
                contact = await _repo.GetById(id);

                if (contact != null)
                {
                    _cache.Set(cacheKey, contact, TimeSpan.FromSeconds(60));
                }
            }

            return contact;
        }
    }
}
