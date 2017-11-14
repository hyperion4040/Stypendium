using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stypendium.Models;

namespace Stypendium.Controllers
{
    
    
    
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private  DataAccess _context;

        public PersonController(DataAccess context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var persons = await _context.Persons
                .ToArrayAsync();
 
            var response = persons.Select(u => new
            {
                id = u.Id,
                name = u.Name
            });
 
            return Ok(response);
        }
        
        
        

        /*// GET
        [HttpGet]
        public  IEnumerable<string> Get()
        {
            var response = 

        }*/

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var persons = await _context.Persons
            .ToArrayAsync();
        
        var response = persons.Where(u => u.Id == id);
        
        return Ok(response);
    }

        [HttpDelete("{id}")]
        public  OkObjectResult Delete(int id)
        {
            Person person =  _context.Persons.Find(id);
            _context.Persons.Remove(person);
            _context.SaveChanges();

            return Ok("Usunięto");
        }
        [HttpPost]
        public OkObjectResult Post(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();

            return Ok("Dodano");
        }

        [HttpPut]
        public OkObjectResult Put(int id, Person person)
        {
            Person oldPerson = _context.Persons.Find(id);
            oldPerson.Name = person.Name;

            _context.Persons.Update(oldPerson);
            
            
            _context.SaveChanges();

            return Ok("Zmieniono");
        }
        
        
    }
}