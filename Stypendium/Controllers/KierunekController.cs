using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using Stypendium.Models;

namespace Stypendium.Controllers
{
    [Route("/api/kierunek")]
    public class KierunekController : Controller
    {
        private  DataAccess _context;

        public KierunekController(DataAccess context)
        {
            _context = context;
        }
        
        
        // GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var kierunek = await _context.Informatyka.ToArrayAsync();
            var przedmiot = await _context.Przedmioty.ToArrayAsync();

            var response = kierunek.Select(
                x => new
                {
                    
                    //Semestr = x.Semestr,
                    Przedmiot = x.Przedmiot.NazwaPrzedmiotu,
                    Ocena = x.Przedmiot.Ocena
                    
                }
            );
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Put(Przedmiot przedmiot)
        {
            var szukanyPrzedmiot = _context.Informatyka.Find(przedmiot.NazwaPrzedmiotu);
            szukanyPrzedmiot.Przedmiot.Ocena = przedmiot.Ocena;
            _context.Informatyka.Update(szukanyPrzedmiot);

            _context.SaveChangesAsync();

            return Ok("Nowa ocena z " + szukanyPrzedmiot.Przedmiot.NazwaPrzedmiotu + " to " +
                      szukanyPrzedmiot.Przedmiot.Ocena);

        }
        
        
    }
}