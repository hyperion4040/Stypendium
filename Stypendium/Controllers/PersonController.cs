using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stypendium.Models;
using StypendiumClient.Models;

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
        public async Task<JsonResult> Get()
        {
            var persons = await _context.Persons
                .ToArrayAsync();
 
            var response = persons.Select(u => new
            { 
                id = u.Id,
                name = u.Name
            }).ToList();
            
            
            
//            return Ok(new {persons = response});
            return Json(new {persons = response});
        }

        
        

       

    [HttpGet("{id}")]
    public async Task<JsonResult> Get(int id)
    {
        var persons = await _context.Persons
            .ToArrayAsync();
        
        var response = persons.Where(u => u.Id == id);
       
        
        
//        return Ok(response);
        return Json(response);
        
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
        public OkObjectResult Put( Person person)
        {
            Person oldPerson = _context.Persons.Find(person.Id);
            oldPerson.Name = person.Name;

            _context.Persons.Update(oldPerson);
            
            
            _context.SaveChanges();

            return Ok("Zmieniono");
        }
        
        
    }
}