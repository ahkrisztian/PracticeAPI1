using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PracticeAPI1.Data;
using PracticeAPI1.DTOs;
using PracticeAPI1.Models;

namespace PracticeAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepo _repo;
        private readonly IMapper _mapper;

        public PeopleController(IPersonRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPersons()
        {
            var persons = _repo.GetAllPersons();

            return Ok(_mapper.Map<IEnumerable<PersonReadDTO>>(persons));
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        public ActionResult<PersonReadDTO> GetPersonById(int id)
        {

            var person = _repo.GetPersonById(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PersonReadDTO>(person));

        }

        [HttpPost]
        public ActionResult<PersonReadDTO> CreatePerson(PersonCreateDTO person)
        {
            var personModel = _mapper.Map<Person>(person);

            _repo.CreatePerson(personModel);

            var personReadDTO = _mapper.Map<PersonReadDTO>(personModel);

            return CreatedAtRoute(nameof(GetPersonById),
                new { Id = personReadDTO.Id }, personReadDTO);
        }

        [HttpPatch("{id}")]
        public ActionResult PartialPersonUpdate(int id, JsonPatchDocument<PersonUpdateDTO> patchDoc)
        {
            var personModelFromRepo = _repo.GetPersonById(id);

            if (personModelFromRepo == null)
            {
                return NotFound();
            }

            var personToPatch = _mapper.Map<PersonUpdateDTO>(personModelFromRepo);

            patchDoc.ApplyTo(personToPatch, ModelState);

            if (!TryValidateModel(personToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(personToPatch, personModelFromRepo);

            _repo.UpdatePerson();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            var personFromRepo = _repo.GetPersonById(id);

            if(personFromRepo == null)
            {
                return NotFound();
            }

            _repo.DeletePerson(personFromRepo);

            return NoContent();
        }

    }
}
