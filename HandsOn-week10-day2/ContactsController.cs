
using Microsoft.AspNetCore.Mvc;
using week10_day2;
using week10_day2.Services;

namespace week10_day2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _service.GetById(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            _service.Add(contact);
            return Created("", contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            contact.Id = id;
            _service.Update(contact);
            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
