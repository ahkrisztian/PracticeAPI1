using Microsoft.AspNetCore.Mvc;
using PracticeAPI1.Data;
using PracticeAPI1.Models;

namespace PracticeAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepo _repo;

        public PeopleController(IPersonRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPersons()
        {
            var persons = _repo.GetAllPersons();

            return Ok(persons);
        }
    }
}
