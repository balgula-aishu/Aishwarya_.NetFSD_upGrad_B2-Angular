using week9_day1.Data;
using week9_day1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace week9_day1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔐 All endpoints require login
    public class ContactsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Contacts.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] // 🔐 Admin only
        public IActionResult Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok(contact);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, Contact updated)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();

            contact.Name = updated.Name;
            contact.Email = updated.Email;
            contact.Phone = updated.Phone;

            _context.SaveChanges();
            return Ok(contact);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();

            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok();
        }
    }
}
