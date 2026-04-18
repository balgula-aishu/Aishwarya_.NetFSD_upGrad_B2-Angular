using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ContactService.Models;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private static List<Contact> contacts = new List<Contact>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(Contact contact)
        {
            contacts.Add(contact);
            return Ok(contact);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, Contact updated)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == id);
            if (contact == null) return NotFound();

            contact.Name = updated.Name;
            contact.Email = updated.Email;
            contact.Phone = updated.Phone;
            contact.CategoryId = updated.CategoryId;

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == id);
            if (contact == null) return NotFound();

            contacts.Remove(contact);
            return Ok("Deleted");
        }
    }
}