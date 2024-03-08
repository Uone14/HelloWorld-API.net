using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PercobaanAPI.Models;

namespace PercobaanAPI.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("api/person")]
        public ActionResult<Person> ListPerson()
        {
            PersonContext context = new PersonContext();
            List<Person> ListPerson = context.ListPerson();
            return Ok(ListPerson);

        }

        [HttpGet("api/person/{id}")]

        public ActionResult<Person> ListPerson(int id)
        {
            PersonContext personContexts = new PersonContext();
            var person = personContexts.ListPerson().FirstOrDefault(p => p.id_person == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}
