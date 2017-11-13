using System.Collections.Generic;
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
        private readonly DataAccess _context;

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
    public string Get(int id)
    {
        return "";
    } 
    }
}