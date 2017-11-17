using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http;
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
        public async /*Task<JsonResult>*/ Task<ActionResult> Get()
        {
            var persons = await _context.Persons
                .ToArrayAsync();
 
            var response = persons.Select(u => new Person
            { 
                Id  = u.Id,
                Name = u.Name
            }).ToList<Person>();
            
            
            
//            return Ok(new {persons = response});
            //return Json(new {persons = response});
            return Ok(response);
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

        [HttpPut/*("{id}/{name}")*/]
        public OkObjectResult Put([FromBody]Person person)
        {
            
            Person oldPerson = _context.Persons.Find(person.Id);
            oldPerson.Name = person.Name;

            _context.Persons.Update(oldPerson);
            
            
            _context.SaveChanges();

            return Ok("Zmieniono");
        }
        
        
    }
}