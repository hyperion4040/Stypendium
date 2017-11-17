using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stypendium.Models;

namespace Stypendium.Controllers
{
    [Route("/api/przedmiot")]
    public class PrzedmiotController : Controller
    {
        private  DataAccess _context;

        public PrzedmiotController(DataAccess context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
//            var przedmioty = await _context.Informatyka.ToArrayAsync();
            var przedmiot = await _context.Przedmioty.ToArrayAsync();
            var response = przedmiot.Select(
                u => new
                {
//                    id = u.Id,
//                    semestr = u.Semestr,
                    przedmiot = u.NazwaPrzedmiotu,
                    ocena = u.Ocena
                }
            ).ToList();
            return Json(new {przedmioty = response});
        }
        [HttpPut/*("{NazwaPrzedmiotu}/{Ocena}")*/]
        public  IActionResult Put([FromBody]Przedmiot przedmiot)
        {
            var staryPrzedmiot =  _context.Przedmioty.Find(przedmiot.NazwaPrzedmiotu);
            staryPrzedmiot.Ocena = przedmiot.Ocena;
            _context.Przedmioty.Update(staryPrzedmiot);
            _context.SaveChanges();

            return Ok("Aktualizacja oceny");

        }
        
        
        
        
    }
}