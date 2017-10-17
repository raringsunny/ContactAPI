using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using contactapi.Models;
using System.Linq;

namespace contactapi.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactDbContext _context;

        public ContactController(ContactDbContext context)
        {
            _context = context;

            if (_context.Contacts.Count() == 0)
            {
                _context.Contacts.Add(new Contact { Name = "Manoj Mohan", Phone = "9686569319", eMail = "sunny.mohan@gmail.com", ZipCode = "134109" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult GetById(long id)
        {
            var item = _context.Contacts.FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}