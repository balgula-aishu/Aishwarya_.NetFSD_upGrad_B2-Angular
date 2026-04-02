using Contact_Management_App.Models;
using Contact_Management_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contact_Management_App.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        // Constructor Injection
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // ✅ Show all contacts
        [HttpGet("")]
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        // ✅ Search by ID
        [HttpGet("get/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            return View(contact);
        }

        // ✅ GET → Show Add Contact Form
        [HttpGet("add")]
        public IActionResult AddContact()
        {
            return View();
        }

        // ✅ POST → Submit Form
        [HttpPost("add")]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            _contactService.AddContact(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}
